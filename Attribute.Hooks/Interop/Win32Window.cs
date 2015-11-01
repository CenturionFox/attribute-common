using System;
using System.Reflection;
using System.Windows.Forms;

namespace Attribute.Hooks.Windows.Interop
{
    public class Win32Window : IWin32Window
    {
        #region [-- CONSTRUCTORS --]

        public Win32Window(object windowObject)
        {
            var caption =
                windowObject.GetType()
                            .InvokeMember("Caption", BindingFlags.GetProperty, null, windowObject, null)
                            .ToString();

            this._hWnd = WinWindowUtility.FindWindow("rctrl_renwnd32", caption);
        }

        public Win32Window(IWin32Window windowObject)
        {
            this._hWnd = windowObject.Handle;
        }

        #endregion


        #region [-- IMPLEMENTED INTERFACES --]

        public IntPtr Handle => this._hWnd;

        #endregion


        #region [-- PUBLIC & PROTECTED METHODS --]

        public bool Show(ShowWindowFlags viewMode)
        {
            return WinWindowUtility.ShowWindow(this.Handle, viewMode);
        }

        public bool ShowAsync(ShowWindowFlags viewMode)
        {
            return WinWindowUtility.ShowWindowAsync(this.Handle, viewMode);
        }

        #endregion


        #region [-- FIELDS --]

        private readonly IntPtr _hWnd;

        #endregion
    }
}
