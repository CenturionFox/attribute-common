using System;

namespace Attribute.Hooks.Windows.Interop
{
    [Flags]
    public enum SetWindowPositionFlags : uint
    {
        /// <summary>
        ///     SWP_ASYNCWINDOWPOS
        /// </summary>
        ASyncWindowPosition = 0x4000,

        /// <summary>
        ///     SWP_DEFERERASE
        /// </summary>
        DeferErase = 0x2000,

        /// <summary>
        ///     SWP_DRAWFRAME
        /// </summary>
        DrawFrame = 0x20,

        /// <summary>
        ///     SWP_FRAMECHANGED
        /// </summary>
        FrameChanged = 0x20,

        /// <summary>
        ///     SWP_HIDEWINDOW
        /// </summary>
        HideWindow = 0x80,

        /// <summary>
        ///     SWP_NOACTIVATE
        /// </summary>
        NoActivate = 0x10,

        /// <summary>
        ///     SWP_NOCOPYBITS
        /// </summary>
        NoCopyBits = 0x100,

        /// <summary>
        ///     SWP_NOMOVE
        /// </summary>
        NoMove = 0x2,

        /// <summary>
        ///     SWP_NOOWNERZORDER
        /// </summary>
        NoOwnerZOrder = 0x200,

        /// <summary>
        ///     SWP_NOREDRAW
        /// </summary>
        NoRedraw = 0x8,

        /// <summary>
        ///     SWP_NOREPOSITION
        /// </summary>
        NoReposition = 0x200,

        /// <summary>
        ///     SWP_NOSENDCHANGING
        /// </summary>
        NoSendChanging = 0x400,

        /// <summary>
        ///     SWP_NOSIZE
        /// </summary>
        NoSize = 0x1,

        /// <summary>
        ///     SWP_NOZORDER
        /// </summary>
        NoZOrder = 0x4,

        /// <summary>
        ///     SWP_SHOWWINDOW
        /// </summary>
        ShowWindow = 0x40
    }
}
