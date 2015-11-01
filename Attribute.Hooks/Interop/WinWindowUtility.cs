using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Attribute.Hooks.Windows.Interop.NativeMethods;

namespace Attribute.Hooks.Windows.Interop
{
    public static class WinWindowUtility
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static bool GetWindowRect(IntPtr hWnd, out Rectangle rectangle)
        {
            Rect r;
            var success = GetWindowRect(hWnd, out r);
            rectangle = (Rectangle)r;

            return success;
        }

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseCapture();

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd,
                                               SetWindowPositionInsertAfterType hWndInsertAfter,
                                               int x,
                                               int y,
                                               int cx,
                                               int cy,
                                               SetWindowPositionFlags uFlags);

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, ShowWindowFlags nCmdShow);

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, ShowWindowFlags nCmdShow);

        #endregion


        #region [-- P/INVOKE --]

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowRect(IntPtr hWnd, out Rect rectangle);

        [DllImport(WinSysUtility.User32, SetLastError = true)]
        internal static extern int MapWindowPoints(IntPtr hWndFrom,
                                                   IntPtr hWndTo,
                                                   [In, Out] ref Rect rect,
                                                   [MarshalAs(UnmanagedType.U4)] int cPoints);

        #endregion
    }
}
