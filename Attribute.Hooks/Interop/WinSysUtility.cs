using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Attribute.Hooks.Windows.Exceptions;

namespace Attribute.Hooks.Windows.Interop
{
    public static class WinSysUtility
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        public static void DisableUserModeCallbackFilter()
        {
            uint flags;
            GetProcessUserModeExceptionPolicy(out flags);

            flags &= ~PROCESS_MODE_FLAGS;
            SetProcessUserModeExceptionPolicy(flags);
        }

        [DllImport(User32, SetLastError = true)]
        public static extern short GetKeyState(Keys key);

        [DllImport(Kernel32),
         Obsolete(
             "This feature does not always return the correct last error code. Use \"WinSysUtility.GetLastErrorCode\" instead."
             )]
        public static extern int GetLastError();

        public static WinSysErrorCodes GetLastErrorCode()
        {
            return (WinSysErrorCodes)Marshal.GetLastWin32Error();
        }

        [DllImport(Kernel32, SetLastError = true)]
        public static extern bool GetProcessUserModeExceptionPolicy(out uint lpFlags);

        public static Exception GetSystemException(WinSysErrorCodes? systemErrorCode = null, string message = null)
        {
            var code = systemErrorCode == null ? GetLastErrorCode() : systemErrorCode.GetValueOrDefault();

            var innerException = message == null
                                     ? new WinSysException(code)
                                     : new WinSysException(code, message);

            var exceptionInit = new object[]
                                {
                                    "Exception caused by system error.",
                                    innerException
                                };

            var e = code.GenerateBoundException(exceptionInit);

            return e ?? innerException;
        }

        [DllImport(User32, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern bool SetProcessUserModeExceptionPolicy(uint dwFlags);

        #endregion


        #region [-- FIELDS --]

        internal const string Kernel32 = "kernel32.dll";
        private const uint PROCESS_MODE_FLAGS = 0x1;
        internal const string User32 = "user32.dll";

        #endregion
    }
}
