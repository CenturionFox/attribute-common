using System;
using System.Runtime.InteropServices;
using Attribute.Hooks.Windows.Interop;
using Attribute.Hooks.Windows.Interop.Messages;
using Attribute.Hooks.Windows.Interop.NativeMethods;

namespace Attribute.Hooks.Windows.Input
{
    /// <summary>
    ///     Contains information about a mouse event passed to a <see cref="LowLevelMouseHook" /> main procedure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LowLevelMouseHookStructure
    {
        private Point _point;
        private int _mouseData;
        private int _flags;
        private int _time;
        private UIntPtr _dwExtraInfo;


        #region [ -- PROPERTIES -- ]

        /// <summary>
        ///     The x- and y-coordinates of the cursor, in screen coordinates.
        /// </summary>
        public Point Point
        {
            get { return this._point; }
            set { this._point = value; }
        }

        /// <summary>
        ///     Data passed form the low level hook. Only used if the event was a mouse wheel or X button event. The high-order
        ///     word specifies either mouse wheel delta or which X button was pressed. The low-order word is always reserved.
        /// </summary>
        public int MouseData
        {
            get { return this._mouseData; }
            set { this._mouseData = value; }
        }

        /// <summary>
        ///     If the message is <see cref="MouseMessage.XButtonDown" />, <see cref="MouseMessage.XButtonUp" />,
        ///     <see cref="MouseMessage.XButtonDoubleClick" />, <see cref="MouseMessage.NonClientXButtonDown" />,
        ///     <see cref="MouseMessage.NonClientXButtonUp" />, or <see cref="MouseMessage.NonClientXButtonDoubleClick" />, this
        ///     value specifies which X button was pressed or released. This value is a member of
        ///     <see cref="LowLevelMouseHookXButtonFlags" />.
        /// </summary>
        public LowLevelMouseHookXButtonFlags XButtonPressed => (LowLevelMouseHookXButtonFlags)(this._mouseData >> 16);

        /// <summary>
        ///     If the message is <see cref="MouseMessage.MouseWheel" /> or <see cref="MouseMessage.MouseWheel" />, this value
        ///     represents the wheel delta. A positive value indicates that the wheel was rotated forward, away from the user; a
        ///     negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as
        ///     <see cref="WHEEL_DELTA" />.
        /// </summary>
        public int WheelDelta => this._mouseData >> 16;

        /// <summary>
        ///     If the message is <see cref="MouseMessage.MouseWheel" /> or <see cref="MouseMessage.MouseWheel" />, this value
        ///     represents the number of clicks that the wheel turned, or <see cref="WheelDelta" /> / <see cref="WHEEL_DELTA" />.
        /// </summary>
        public int WheelClicks => this.WheelDelta / WHEEL_DELTA;

        public HookInjectionFlags InjectionFlags
        {
            get
            {
                var flag = HookInjectionFlags.None;
                if ((this._flags & 1) != 0)
                {
                    flag |= HookInjectionFlags.Injected;
                }

                if ((this._flags & (1 << 1)) != 0)
                {
                    flag |= HookInjectionFlags.LowerIntegrityLevelInjected;
                }

                return flag;
            }
            set
            {
                switch (value)
                {
                    case HookInjectionFlags.Injected | HookInjectionFlags.LowerIntegrityLevelInjected:
                        this._flags |= 1 << 1;
                        goto case HookInjectionFlags.Injected;

                    case HookInjectionFlags.LowerIntegrityLevelInjected:
                        this._flags |= 1 << 1;
                        break;

                    case HookInjectionFlags.Injected:
                        this._flags |= 1;
                        break;

                    default:
                        this._flags &= ~(1 | 1 << 1);
                        break;
                }
            }
        }

        /// <summary>
        ///     The time stamp for this message.
        /// </summary>
        public int Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        /// <summary>
        ///     Additional information associated with the message.
        /// </summary>
        public UIntPtr ExtraInfo
        {
            get { return this._dwExtraInfo; }
            set { this._dwExtraInfo = value; }
        }

        #endregion


        #region [ -- FIELDS -- ]

        private const int WHEEL_DELTA = 0x78;

        #endregion
    }
}
