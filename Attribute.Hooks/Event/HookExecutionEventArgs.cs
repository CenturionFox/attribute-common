using System;

namespace Attribute.Hooks.Windows.Event
{
    /// <summary>
    ///     Execution event arguments for the <see cref="HookExecutionEventHandler" />.
    /// </summary>
    public class HookExecutionEventArgs : EventArgs
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates a new empty instance of <see cref="HookExecutionEventArgs" />.
        /// </summary>
        public HookExecutionEventArgs()
        {
        }

        /// <summary>
        ///     Creates a new instance of <see cref="HookExecutionEventArgs" />.
        /// </summary>
        /// <param name="nCode">The hook execution state code.</param>
        /// <param name="wParam">A dynamic WORD parameter that was passed to and / or marshaled from the hook.</param>
        /// <param name="lParam">A dynamic LONG parameter that was passed to and / or marshaled from the hook.</param>
        public HookExecutionEventArgs(int nCode, dynamic wParam, dynamic lParam)
        {
            this.NCode = nCode;
            this.WParam = wParam;
            this.LParam = lParam;
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The lParam value passed to / marshaled from the hook.
        /// </summary>
        public dynamic LParam { get; private set; }

        /// <summary>
        ///     The execution flags of the hook.
        /// </summary>
        public int NCode { get; set; }

        /// <summary>
        ///     The WORD parameter value passed to / marhsaled from the hook.
        /// </summary>
        public dynamic WParam { get; set; }

        #endregion
    }
}
