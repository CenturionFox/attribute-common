using System;
using Attribute.Hooks.Windows.Interop;
using Attribute.Hooks.Windows.Interop.Messages;

namespace Attribute.Hooks.Windows.Input
{
    /// <summary>
    ///     The high-order word specification within a <see cref="LowLevelMouseHookStructure" />'s
    ///     <see cref="LowLevelMouseHookStructure.MouseData" /> value when the <see cref="MouseMessage" /> is one of the
    ///     X-button messages.
    /// </summary>
    [Flags]
    public enum LowLevelMouseHookXButtonFlags : short
    {
        /// <summary>
        ///     The first X button was pressed or released.
        /// </summary>
        /// <remarks>Win32 Name: XBUTTON1</remarks>
        XButton1 = 0x1,

        /// <summary>
        ///     The second X button was pressed or released.
        /// </summary>
        /// <remarks>Win32 Name: XBUTTON2</remarks>
        XButton2 = 0x2
    }
}
