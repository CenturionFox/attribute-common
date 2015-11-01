using Attribute.Hooks.Windows.Codes;
using Attribute.Hooks.Windows.Event.Generic;
using Attribute.Hooks.Windows.Interop;
using Attribute.Hooks.Windows.Interop.Messages;

namespace Attribute.Hooks.Windows.Input.Event
{
    /// <summary>
    ///     Event arguments for a <see cref="LowLevelMouseHook.HookExecution" /> event.
    /// </summary>
    public sealed class LowLevelMouseHookExecutionEventArgs :
        HookExecutionEventArgs<MouseMessage, LowLevelMouseHookStructure>
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates new empty instance of <see cref="LowLevelMouseHookExecutionEventArgs" />.
        /// </summary>
        public LowLevelMouseHookExecutionEventArgs()
        {
        }

        /// <summary>
        ///     Creates new instance of <see cref="LowLevelMouseHookExecutionEventArgs" />.
        /// </summary>
        /// <param name="nCode">The <see cref="WinHookCode" /> of this execution event.</param>
        /// <param name="wParam">
        ///     The WORD parameter passed to the <see cref="LowLevelMouseHook.MainProcedure" />, cast to a
        ///     <see cref="MouseMessage" />.
        /// </param>
        /// <param name="lParam">
        ///     The LONG parameter passed to the <see cref="LowLevelMouseHook.MainProcedure" />, marshaled as a
        ///     <see cref="LowLevelMouseHookStructure" />.
        /// </param>
        public LowLevelMouseHookExecutionEventArgs(WinHookCode nCode,
                                                   MouseMessage wParam,
                                                   LowLevelMouseHookStructure lParam)
            : base((int)nCode, wParam, lParam)
        {
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The <see cref="WinHookCode" /> execution state of the hook.
        /// </summary>
        public new WinHookCode NCode
        {
            get { return (WinHookCode)base.NCode; }
            set { base.NCode = (int)value; }
        }

        #endregion
    }
}
