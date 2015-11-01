using System.Windows.Forms;
using Attribute.Hooks.Windows.Codes;
using Attribute.Hooks.Windows.Event.Generic;

namespace Attribute.Hooks.Windows.Input.Event
{
    public class LowLevelKeyboardHookExecutionEventArgs : HookExecutionEventArgs<Keys, LowLevelKeyboardHookStructure>
    {
        #region [-- CONSTRUCTORS --]

        public LowLevelKeyboardHookExecutionEventArgs()
        {
        }

        public LowLevelKeyboardHookExecutionEventArgs(WinHookCode nCode,
                                                      Keys wParam,
                                                      LowLevelKeyboardHookStructure lParam)
            : base((int)nCode, wParam, lParam)
        {
        }

        #endregion


        #region [-- PROPERTIES --]

        public new WinHookCode NCode
        {
            get { return (WinHookCode)base.NCode; }
            set { base.NCode = (int)value; }
        }

        #endregion
    }
}
