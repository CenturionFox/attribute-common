using System;

namespace Attribute.Hooks.Windows.Interop
{
    [Flags]
    public enum ShowWindowFlags
    {
        /// <summary>
        ///     SW_HIDE
        /// </summary>
        Hide = 0x0,

        /// <summary>
        ///     SW_SHOWNORMAL
        /// </summary>
        ShowNormal = 0x1,

        /// <summary>
        ///     SW_SHOWMINIMIZED
        /// </summary>
        ShowMinimized = 0x2,

        /// <summary>
        ///     SW_MAXIMIZE
        /// </summary>
        Maximize = 0x3,

        /// <summary>
        ///     SW_SHOWMAXIMIZED
        /// </summary>
        ShowMaximized = 0x3,

        /// <summary>
        ///     SW_SHOWNOACTIVATE
        /// </summary>
        ShowNoActivate = 0x4,

        /// <summary>
        ///     SW_SHOW
        /// </summary>
        Show = 0x5,

        /// <summary>
        ///     SW_MINIMIZE
        /// </summary>
        Minimize = 0x6,

        /// <summary>
        ///     SW_SHOWMINNOACTIVE
        /// </summary>
        ShowMinimizedNoActivate = 0x7,

        /// <summary>
        ///     SW_SHOWNA
        /// </summary>
        ShowNonActivated = 0x8,

        /// <summary>
        ///     SW_RESTORE
        /// </summary>
        Restore = 0x9,

        /// <summary>
        ///     SW_SHOWDEFAULT
        /// </summary>
        ShowDefault = 0xa,

        /// <summary>
        ///     SW_FORCEMINIMIZE
        /// </summary>
        ForceMinimize = 0xb
    }
}
