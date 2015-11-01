namespace Attribute.Hooks.Windows.Input
{
    /// <summary>
    ///     Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate. This
    ///     can happen, for example, when the cursor moves, when a mouse button is pressed or released, or in response to a
    ///     call to a function such as WindowFromPoint. If the mouse is not captured, the message is sent to the window beneath
    ///     the cursor. Otherwise, the message is sent to the window that has captured the mouse.
    /// </summary>
    /// <remarks>Documentation from "https://msdn.microsoft.com/en-us/library/windows/desktop/ms645618%28v=vs.85%29.aspx"</remarks>
    public enum NonClientHitTestResult
    {
        /// <summary>
        ///     On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc
        ///     function produces a system beep to indicate an error).
        /// </summary>
        /// <remarks>Win32 Name:  HTERROR</remarks>
        Error = -2,

        /// <summary>
        ///     In a window currently covered by another window in the same thread (the message will be sent to underlying windows
        ///     in the same thread until one of them returns a code that is not <see cref="Transparent" />).
        /// </summary>
        /// <remarks>Win32 Name:  HTTRANSPARENT</remarks>
        Transparent = -1,

        /// <summary>
        ///     On the screen background or on a dividing line between windows.
        /// </summary>
        /// <remarks>Win32 Name:  HTNOWHERE</remarks>
        Nowhere = 0,

        /// <summary>
        ///     In a client area.
        /// </summary>
        /// <remarks>Win32 Name:  HTCLIENT</remarks>
        Client = 1,

        /// <summary>
        ///     In a title bar.
        /// </summary>
        /// <remarks>Win32 Name:  HTCAPTION</remarks>
        Caption = 2,

        /// <summary>
        ///     In a size box (same as <see cref="Size" />).
        /// </summary>
        /// <remarks>Win32 Name:  HTGROWBOX</remarks>
        GrowBox = 4,

        /// <summary>
        ///     In a menu.
        /// </summary>
        /// <remarks>Win32 Name:  HTMENU</remarks>
        Menu = 5,

        /// <summary>
        ///     In a horizontal scroll bar.
        /// </summary>
        /// <remarks>Win32 Name:  HTHSCROLL</remarks>
        HorizontalScroll = 6,

        /// <summary>
        ///     In a Maximize button (same as <see cref="Zoom" />).
        /// </summary>
        /// <remarks>Win32 Name:  HTMAXBUTTON</remarks>
        MaximizeButton = 9,

        /// <summary>
        ///     In the left border of a sizable window (the user can click the mouse to resize the window horizontally).
        /// </summary>
        /// <remarks>Win32 Name:  HTLEFT</remarks>
        Left = 10,

        /// <summary>
        ///     In the lower-horizontal border of a sizable window (the user can click the mouse to resize the window
        ///     vertically).
        /// </summary>
        /// <remarks>Win32 Name:  HTBOTTOM</remarks>
        Bottom = 15,

        /// <summary>
        ///     In the lower-left corner of a border of a sizable window (the user can click the mouse to resize the window
        ///     diagonally).
        /// </summary>
        /// <remarks>Win32 Name:  HTBOTTOMLEFT</remarks>
        BottomLeft = 16,

        /// <summary>
        ///     In the lower-right corner of a border of a sizable window (the user can click the mouse to resize the window
        ///     diagonally).
        /// </summary>
        /// <remarks>Win32 Name:  HTBOTTOMRIGHT</remarks>
        BottomRight = 17,

        /// <summary>
        ///     In the border of a window that does not have a sizing border.
        /// </summary>
        /// <remarks>Win32 Name:  HTBORDER</remarks>
        Border = 18,

        /// <summary>
        ///     In a Close button.
        /// </summary>
        /// <remarks>Win32 Name:  HTCLOSE</remarks>
        Close = 20,

        /// <summary>
        ///     In a Help button.
        /// </summary>
        /// <remarks>Win32 Name:  HTHELP</remarks>
        Help = 21,

        /// <summary>
        ///     In a Minimize button (same as <see cref="Reduce" />).
        /// </summary>
        /// <remarks>Win32 Name:  HTMINBUTTON</remarks>
        MinimizeButton = 8,

        /// <summary>
        ///     In a Minimize button (same as <see cref="MinimizeButton" />).
        /// </summary>
        /// <remarks>Win32 Name:  HTREDUCE</remarks>
        Reduce = 8,

        /// <summary>
        ///     In the right border of a sizable window (the user can click the mouse to resize the window horizontally).
        /// </summary>
        /// <remarks>Win32 Name:  HTRIGHT</remarks>
        Right = 11,

        /// <summary>
        ///     In a size box (same as <see cref="GrowBox" />).
        /// </summary>
        /// <remarks>Win32 Name:  HTSIZE</remarks>
        Size = 4,

        /// <summary>
        ///     In a window menu or in a Close button in a child window.
        /// </summary>
        /// <remarks>Win32 Name:  HTSYSMENU</remarks>
        SystemMenu = 3,

        /// <summary>
        ///     In the upper-horizontal border of a window.
        /// </summary>
        /// <remarks>Win32 Name: HTTOP</remarks>
        Top = 12,

        /// <summary>
        ///     In the upper-left corner of a window border.
        /// </summary>
        /// <remarks>Win32 Name:  HTTOPLEFT</remarks>
        TopLeft = 13,

        /// <summary>
        ///     In the upper-right corner of a window border.
        /// </summary>
        /// <remarks>Win32 Name:  HTTOPRIGHT</remarks>
        TopRight = 14,

        /// <summary>
        ///     In the vertical scroll bar.
        /// </summary>
        /// <remarks>Win32 Name:  HTVSCROLL</remarks>
        VerticalScroll = 7,

        /// <summary>
        ///     In a Maximize button (same as <see cref="MaximizeButton" />).
        /// </summary>
        /// <remarks>Win32 Name:  HTZOOM</remarks>
        Zoom = 9
    }
}
