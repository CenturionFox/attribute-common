namespace Attribute.Hooks.Windows.Event.Generic
{
    /// <summary>
    ///     Execution event arguments for the generic <see cref="HookExecutionEventHandler{TWParam,TLParam,TReturn}" />.
    /// </summary>
    /// <typeparam name="TWParam">The type of the WORD parameter passed and / or marshaled from the hook.</typeparam>
    /// <typeparam name="TLParam">The type of the LONG parameter passed and / or marshaled from the hook.</typeparam>
    public class HookExecutionEventArgs<TWParam, TLParam> : HookExecutionEventArgs
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates a new empty generic <see cref="HookExecutionEventArgs{TWParam, TLParam}" />.
        /// </summary>
        public HookExecutionEventArgs()
        {
        }

        /// <summary>
        ///     Creates a new generic <see cref="HookExecutionEventArgs{TWParam, TLParam}" />.
        /// </summary>
        /// <param name="nCode">The hook execution state code.</param>
        /// <param name="wParam">
        ///     The WORD parameter (of type <see cref="TWParam" />) that was passed to and / or marshaled from the
        ///     hook.
        /// </param>
        /// <param name="lParam">
        ///     The LONG paramerer (of type <see cref="TLParam" />) that was passed to and / or marshaled from the
        ///     hook.
        /// </param>
        public HookExecutionEventArgs(int nCode, TWParam wParam, TLParam lParam)
            : base(nCode, wParam, lParam)
        {
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The marshaled LONG parameter (of type <see cref="TLParam" />) that was passed to / marshaled from the hook.
        /// </summary>
        public new TLParam LParam
        {
            get { return (TLParam)base.LParam; }
            set { base.WParam = value; }
        }

        /// <summary>
        ///     The marshaled WORD parameter (of type <see cref="TWParam" />) that was passed to / marshaled from the hook.
        /// </summary>
        public new TWParam WParam
        {
            get { return (TWParam)base.WParam; }
            set { base.WParam = value; }
        }

        #endregion
    }
}
