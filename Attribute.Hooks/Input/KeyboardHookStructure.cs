using System;

namespace Attribute.Hooks.Windows.Input
{
    public struct KeyboardHookStructure
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates a new KeyboardHookStructure from the bit information stored in the keyboard hook structure.
        /// </summary>
        /// <param name="lParam">The key information passed from the hook in a LONG parameter value.</param>
        public KeyboardHookStructure(int lParam = 0)
            : this()
        {
            this.LParam = lParam;
        }

        #endregion


        #region [-- PROPERTIES --]

        public bool IsAltPressed { get; set; }

        public bool IsExtendedKey { get; set; }

        public bool IsKeyBeingReleased { get; set; }

        /// <summary>
        ///     Constructs the keyboard information value from the structure.
        /// </summary>
        public int LParam
        {
            get
            {
                var lParam = this.IsKeyBeingReleased ? 1 << 31 : 0;

                if (this.WasKeyHeld)
                {
                    lParam |= 1 << 30;
                }

                if (this.IsAltPressed)
                {
                    lParam |= 1 << 29;
                }

                if (this.IsExtendedKey)
                {
                    lParam |= 1 << 24;
                }

                lParam |= (this.ScanCode & 0x7f) << 16;
                lParam |= this.RepeatCount & 0x7fff;

                return lParam;
            }
            private set
            {
                this.RepeatCount = Convert.ToInt16(value & 0xffff);
                this.ScanCode = Convert.ToByte((value >> 16) & 0xff);
                this.IsExtendedKey = (value & (1 << 24)) != 0;
                this.IsAltPressed = (value & (1 << 29)) != 0;
                this.WasKeyHeld = (value & (1 << 30)) != 0;
                this.IsKeyBeingReleased = (value & (1 << 31)) != 0;
            }
        }

        public short RepeatCount { get; set; }

        public byte ScanCode { get; set; }

        public bool WasKeyHeld { get; set; }

        #endregion
    }
}
