using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Attribute.Hooks.Windows.Input
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LowLevelKeyboardHookStructure
    {
        private Keys _keyCode;
        private byte _scanCode;
        private int _flags;
        private long _time;
        private UIntPtr _dwExtraInfo;

        public Keys KeyCode
        {
            get { return this._keyCode; }
            set { this._keyCode = value; }
        }

        public byte ScanCode
        {
            get { return this._scanCode; }
            set { this._scanCode = value; }
        }

        public bool IsExtended
        {
            get { return (this._flags & 1) != 0; }
            set
            {
                if (value)
                {
                    this._flags |= 1;
                }
                else
                {
                    this._flags &= ~1;
                }
            }
        }

        public HookInjectionFlags InjectionFlags
        {
            get
            {
                var flag = HookInjectionFlags.None;
                if ((this._flags & 1 << 4) != 0)
                {
                    flag |= HookInjectionFlags.Injected;
                }

                if ((this._flags & 1 << 1) != 0)
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
                        this._flags |= 1 << 4;
                        break;

                    default:
                        this._flags &= ~(1 << 4 | 1 << 1);
                        break;
                }
            }
        }

        public bool IsAltPressed
        {
            get { return (this._flags & 1 << 5) != 0; }
            set { this._flags = value ? this._flags | 1 << 5 : this._flags & ~(1 << 5); }
        }

        public bool IsKeyBeingReleased
        {
            get { return (this._flags & 1 << 7) != 0; }
            set { this._flags = value ? this._flags | 1 << 7 : this._flags & ~(1 << 7); }
        }

        public long Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        public UIntPtr ExtraInfo
        {
            get { return this._dwExtraInfo; }
            set { this._dwExtraInfo = value; }
        }
    }
}
