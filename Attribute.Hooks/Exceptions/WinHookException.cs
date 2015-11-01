using System;

namespace Attribute.Hooks.Windows.Exceptions
{
    public sealed class WinHookException : Exception
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates a new WinHookException without a bound hook.
        /// </summary>
        public WinHookException()
            : this(hook: null)
        {
        }

        /// <summary>
        ///     Creates a new WinHookException without a bound hook and with the specified message.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public WinHookException(string message)
            : this(null, message)
        {
        }

        /// <summary>
        ///     Creates a new WinHookException without a bound hook and with the specified message.  The inner exception that
        ///     caused this exception is also specified.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">
        ///     The exception that caused this exception to be thrown.  Generally a
        ///     <see cref="WinSysException" />.
        /// </param>
        public WinHookException(string message, Exception innerException)
            : this(null, message, innerException)
        {
        }

        /// <summary>
        ///     Creates a new WinHookException bound to the specified hook.  The message is set accordingly.
        /// </summary>
        /// <param name="hook">The hook that caused the exception to be thrown.</param>
        public WinHookException(WinHookBase hook)
            : base(hook == null ? null : $"The hook {hook} errored.")
        {
            this.setUpHookData(hook);
        }

        /// <summary>
        ///     Creates a new WinHookException bound to the specified hook, with the specified exception message.
        /// </summary>
        /// <param name="hook">The hook that caused the exception to be thrown.</param>
        /// <param name="message">The exception message.</param>
        public WinHookException(WinHookBase hook, string message)
            : base(message)
        {
            this.setUpHookData(hook);
        }

        /// <summary>
        ///     Creates a new WinHookException bound to a specific hook, with the specified exception message, and the specified
        ///     inner exception.
        /// </summary>
        /// <param name="hook">The hook that caused the exception to be thrown.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">
        ///     The exception that caused this exception to be thrown.  Generally a
        ///     <see cref="WinSysException" />.
        /// </param>
        public WinHookException(WinHookBase hook, string message, Exception innerException)
            : base(message, innerException)
        {
            this.setUpHookData(hook);
        }

        #endregion


        #region [-- PRIVATE METHODS --]

        private void setUpHookData(WinHookBase hook)
        {
            this.Hook = hook;

            if (hook != null)
            {
                this.Data.Add("HookID", hook.HookId);
                this.Data.Add("Attached", hook.Attached);
                this.Data.Add("MainProcedure", hook.MainProcedure);
            }
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The hook that caused this exception to be raised.
        /// </summary>
        public WinHookBase Hook { get; private set; }

        #endregion
    }
}
