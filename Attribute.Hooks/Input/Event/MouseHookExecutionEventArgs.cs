using Attribute.Hooks.Windows.Codes;
using Attribute.Hooks.Windows.Event.Generic;
using Attribute.Hooks.Windows.Interop;
using Attribute.Hooks.Windows.Interop.Messages;

namespace Attribute.Hooks.Windows.Input.Event
{
    /// <summary>
    ///     Event arguments for a <see cref="MouseHook.HookExecution" /> event.
    /// </summary>
    public sealed class MouseHookExecutionEventArgs : HookExecutionEventArgs<MouseMessage, MouseHookStructure>
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates a new instance of <see cref="MouseHookExecutionEventArgs" />.
        /// </summary>
        public MouseHookExecutionEventArgs()
        {
        }

        public MouseHookExecutionEventArgs(WinHookCode nCode, MouseMessage wParam, MouseHookStructure lParam)
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
