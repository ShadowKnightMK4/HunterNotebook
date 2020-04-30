using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Noteformat
{
    [Flags]
    public enum StringEncodingData: int
    {
        /// <summary>
        /// string is encoded as commpressed unicode
        /// </summary>
        UNICODE_STRING = 1,
        /// <summary>
        /// encoded as compressed ansi
        /// </summary>
        ANSI_STRING = 2,
        /// <summary>
        /// string is richtext data
        /// </summary>
        RICHTEXT = 4,
        /// <summary>
        /// string is not richtext data
        /// </summary>

        PLAINTEXT = 8
    }

    
    [Serializable]
    public class NoteDocumentHeader
    {
        public static  string MagicId = "ZIPTXT";
        public StringEncodingData StringEncoding;
        public int EncodingLength;

        public void WriteBytes(Stream Output)
        {
            var WriteOut = new BinaryWriter(Output);
            {
                var MagicBytes = Encoding.ASCII.GetBytes(MagicId);
                WriteOut.Write(MagicBytes, 0, MagicBytes.Length);
                WriteOut.Write((int)StringEncoding);
                WriteOut.Write(EncodingLength);
            }
            
        }

        public NoteDocumentHeader()
        {

        }

        public NoteDocumentHeader(Stream Input)
        {
            using (var ReadIn = new BinaryReader(Input))
            {

                string MagicIdTest =  Encoding.ASCII.GetChars(ReadIn.ReadBytes(MagicId.Length)).ToString();
                if (MagicIdTest != MagicId)
                {
                    // throw new MagicIdDocCheckFailureException();
                    throw new InvalidDataException();
                }
                StringEncoding = (StringEncodingData) ReadIn.ReadInt32();
                EncodingLength = ReadIn.ReadInt32();
            }
        }
    }


    public class NoteDocument
    {
        public NoteDocument()
        {
            EncodingData = StringEncodingData.RICHTEXT | StringEncodingData.UNICODE_STRING;
        }

        public void Save(string FileName)
        {
            using (FileStream Handler = File.OpenWrite(FileName))
            {
                SaveToStream(Handler);
            }
        }

        /// <summary>
        /// make from this file.
        /// </summary>
        /// <param name="Source"></param>
        public NoteDocument(Stream Source)
        {
            var Header = new NoteDocumentHeader(Source);
            byte[] UncompressedBytes = new byte[Header.EncodingLength];
            using (var ComressedStream = new GZipStream(Source, CompressionLevel.Fastest))
            {
                 ComressedStream.Read(UncompressedBytes, 0, Header.EncodingLength);
            }
            CoreString = Encoding.UTF8.GetString(UncompressedBytes);
        }
        public void SaveToStream(Stream Target)
        {
            var Header = new NoteDocumentHeader();
            MemoryStream EncodedString;
            GZipStream Smallstring = null;
            byte[] CompressedBytes;
            try
            {
                Smallstring = new GZipStream(EncodedString = new MemoryStream(), CompressionLevel.Fastest);
                byte[] UncompressedBytes = Encoding.UTF8.GetBytes(CoreString);
                Smallstring.Write(UncompressedBytes, 0, UncompressedBytes.Length);
            }
            finally
            {
                Smallstring?.Dispose();
            }

            CompressedBytes = EncodedString.GetBuffer();
            Header.StringEncoding = EncodingData;
            Header.EncodingLength = CompressedBytes.Length;

            Header.WriteBytes(Target);
            Target.Write(CompressedBytes, 0, CompressedBytes.Length);
            
            
        }
        public string CoreString;
        public StringEncodingData EncodingData;

    }


 
}
