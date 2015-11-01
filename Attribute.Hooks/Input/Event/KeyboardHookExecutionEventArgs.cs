using System.Windows.Forms;
using Attribute.Hooks.Windows.Codes;
using Attribute.Hooks.Windows.Event.Generic;

namespace Attribute.Hooks.Windows.Input.Event
{
    public class KeyboardHookExecutionEventArgs : HookExecutionEventArgs<Keys, KeyboardHookStructure>
    {
        #region [-- CONSTRUCTORS --]

        public KeyboardHookExecutionEventArgs()
        {
        }

        public KeyboardHookExecutionEventArgs(WinHookCode nCode, Keys wParam, KeyboardHookStructure lParam)
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
