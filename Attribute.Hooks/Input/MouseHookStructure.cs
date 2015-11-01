using System;
using System.Runtime.InteropServices;
using Attribute.Hooks.Windows.Interop.NativeMethods;

namespace Attribute.Hooks.Windows.Input
{
    /// <summary>
    ///     Contains information about a mouse event passed to a <see cref="MouseHook" /> main procedure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseHookStructure
    {
        private Point pt;
        private int hWnd;
        private NonClientHitTestResult _wHitTestResultCode;
        private UIntPtr dwExtraInfo;


        #region [ -- PROPERTIES -- ]

        /// <summary>
        ///     The x- and y-coordinates of the cursor, in screen coordinates.
        /// </summary>
        public Point Point
        {
            get { return this.pt; }
            set { this.pt = value; }
        }

        /// <summary>
        ///     A handle to the window that will receive the mouse message corresponding to the mouse event.
        /// </summary>
        public int HWnd
        {
            get { return this.hWnd; }
            set { this.hWnd = value; }
        }

        /// <summary>
        ///     The hit-test value. For the descriptions of the hit-test values, see the values within the
        ///     <see cref="NonClientHitTestResult" /> enum.
        /// </summary>
        public NonClientHitTestResult HitTestResultCode
        {
            get { return this._wHitTestResultCode; }
            set { this._wHitTestResultCode = value; }
        }

        /// <summary>
        ///     Additional information associated with the message.
        /// </summary>
        public UIntPtr ExtraInfo
        {
            get { return this.dwExtraInfo; }
            set { this.dwExtraInfo = value; }
        }

        #endregion
    }
}
