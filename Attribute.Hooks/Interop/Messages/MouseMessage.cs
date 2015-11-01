using System.Data;
using Attribute.Common.Attributes.Enumeration;

namespace Attribute.Hooks.Windows.Interop.Messages
{
    /// <summary>
    ///     Message definitions for mouse messages.
    /// </summary>
    public enum MouseMessage
    {
        [DisplayValue("Mouse Move"), DataValue("WM_MOUSEMOVE")]
        MouseMove = 0x0200,

        [DisplayValue("Left Button Down"), DataValue("WM_LBUTTONDOWN")]
        LeftButtonDown = 0x0201,

        [DisplayValue("Left Button Up"), DataValue("WM_LBUTTONUP")]
        LeftButtonUp = 0x0202,

        [DisplayValue("Left Button Double Click"), DataValue("WM_LBUTTONDBLCLK")]
        LeftButtonDoubleClick = 0x0203,

        [DisplayValue("Right Button Down"), DataValue("WM_RBUTTONDOWN")]
        RightButtonDown = 0x0204,

        [DisplayValue("Right Button Up"), DataValue("WM_RBUTTONUP")]
        RightButtonUp = 0x0205,

        [DisplayValue("Right Button Double Click"), DataValue("WM_RBUTTONDBLCLK")]
        RightButtonDoubleClick = 0x0206,

        [DisplayValue("Middle Button Down"), DataValue("WM_MBUTTONDOWN")]
        MiddleButtonDown = 0x0207,

        [DisplayValue("Middle Button Up"), DataValue("WM_MBUTTONUP")]
        MiddleButtonUp = 0x0208,

        [DisplayValue("Middle Button Double Click"), DataValue("WM_MBUTTONDBLCLK")]
        MiddleButtonDoubleClick = 0x0209,

        [DisplayValue("Mouse Wheel 0"), DataValue("WM_MOUSEWHEEL_0")]
        MouseWheel = 0x020A,

        [DisplayValue("X Button Down"), DataValue("WM_XBUTTONDOWN")]
        XButtonDown = 0x020B,

        [DisplayValue("X Button Up"), DataValue("WM_XBUTTONUP")]
        XButtonUp = 0x020C,

        [DisplayValue("X Button Double Click"), DataValue("WM_XBUTTONDBLCLK")]
        XButtonDoubleClick = 0x020D,

        [DisplayValue("Mouse Wheel 1"), DataValue("WM_MOUSEWHEEL_1")]
        MouseWheel1 = 0x020E,

        [DisplayValue("Non-Client Mouse Move"), DataValue("WM_NCMOUSEMOVE")]
        NonClientMouseMove = 0x00A0,

        [DisplayValue("Non-Client Left Button Down"), DataValue("WM_NCLBUTTONDOWN")]
        NonClientLeftButtonDown = 0x00A1,

        [DisplayValue("Non-Client Left Button Up"), DataValue("WM_NCLBUTTONUP")]
        NonClientLeftButtonUp = 0x00A2,

        [DisplayValue("Non-Client Left Button Double Click"), DataValue("WM_NCLBUTTONDBLCLK")]
        NonClientLeftButtonDoubleClick = 0x00A3,

        [DisplayValue("Non-Client Right Button Down"), DataValue("WM_NCRBUTTONDOWN")]
        NonClientRightButtonDown = 0x00A4,

        [DisplayValue("Non-Client Right Button Up"), DataValue("WM_NCRBUTTONUP")]
        NonClientRightButtonUp = 0x00A5,

        [DisplayValue("Non-Client Right Button Double Click"), DataValue("WM_NCRBUTTONDBLCLK")]
        NonClientRightButtonDoubleClick = 0x00A6,

        [DisplayValue("Non-Client Middle Button Down"), DataValue("WM_NCMBUTTONDOWN")]
        NonClientMiddleButtonDown = 0x00A7,

        [DisplayValue("Non-Client Middle Button Up"), DataValue("WM_NCMBUTTONUP")]
        NonClientMiddleButtonUp = 0xa8,

        [DisplayValue("Non-Client Middle Button Double Click"), DataValue("WM_NCMBUTTONDBLCLK")]
        NonClientMiddleButtonDoubleClick = 0x00A9,

        [DisplayValue("Non-Client Mouse Wheel 0"), DataValue("WM_NCMOUSEWHEEL_0")]
        NonClientMouseWheel = 0x00AA,

        [DisplayValue("Non-Client X Button Down"), DataValue("WM_NCXBUTTONDOWN")]
        NonClientXButtonDown = 0x00AB,

        [DisplayValue("Non-Client X Button Up"), DataValue("WM_NCXBUTTONUP")]
        NonClientXButtonUp = 0x00AC,

        [DisplayValue("Non-Client X Button Double Click"), DataValue("WM_NCXBUTTONDBLCLK")]
        NonClientXButtonDoubleClick = 0x00AD,

        [DisplayValue("Non-Client Mouse Wheel 1"), DataValue("WM_NCMOUSEWHEEL_1")]
        NonClientMouseWheel1 = 0x00AE
    }
}
