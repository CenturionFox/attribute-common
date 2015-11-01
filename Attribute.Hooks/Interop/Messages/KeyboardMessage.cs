using Attribute.Common.Attributes.Enumeration;

namespace Attribute.Hooks.Windows.Interop.Messages
{
    public enum KeyboardMessage
    {
        [DisplayValue("Key Down"), DataValue("WM_KEYDOWN")]
        KeyDown = 0x100,
        [DisplayValue("Key Up"), DataValue("WM_KEYUP")]
        KeyUp = 0x101,
        [DisplayValue("System Key Down"), DataValue("WM_SYSKEYDOWN")]
        SysKeyDown = 0x104,
        [DisplayValue("System Key Up"), DataValue("WM_SYSKEYUP")]
        SysKeyUp = 0x105
    }
}
