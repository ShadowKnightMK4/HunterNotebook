using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HunterNotebook
{
    /// <summary>
    /// some internal settings that get baked into a compile. The implemention is
    /// flexible in being able to change if these are changed but this is used for select feature tweaking.
    /// </summary>
    internal static class InternalConfig
    {
        /// <summary>
        /// if true then RTF saving and loading is disabled.
        /// </summary>
        public static bool DisableRTF = true;
        /// <summary>
        /// If true then the zip format is diabled
        /// </summary>
        public static bool DisableZip = true;

        /// <summary>
        ///  set to true to use Times new Roman 12 and liked it.
        /// </summary>
        public static bool DisableFontSupport = false;

        /// <summary>
        ///  turn off the feature suggestion box
        /// </summary>
        public static bool DisableFeatureSuggestion = true;

#if DEBUG
        /// <summary>
        /// Set this to turn of the delete teh debug config on exit
        /// </summary>
        public static bool DisableDebugConfigDeleteOnExit = false;       
#endif
    }
}
