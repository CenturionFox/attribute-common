namespace Attribute.Hooks.Windows.Interop
{
    public enum SetWindowPositionInsertAfterType
    {
        /// <summary>
        ///     HWND_BOTTOM
        /// </summary>
        Bottom = 0x1,

        /// <summary>
        ///     HWND_NOTOPMOST
        /// </summary>
        NoTopMost = -0x2,

        /// <summary>
        ///     HWND_TOP
        /// </summary>
        Top = 0x0,

        /// <summary>
        ///     HWND_TOPMOST
        /// </summary>
        TopMost = -0x1
    }
}
