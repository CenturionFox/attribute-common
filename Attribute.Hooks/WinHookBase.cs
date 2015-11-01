using System;
using System.Runtime.InteropServices;
using Attribute.Common.Attributes.Enumeration;
using Attribute.Common.Extensions;
using Attribute.Hooks.Windows.Codes;
using Attribute.Hooks.Windows.Exceptions;

namespace Attribute.Hooks.Windows
{
    /// <summary>
    ///     Models a basic <see cref="IWinHook" />. All hooks should extend this class.
    /// </summary>
    public abstract class WinHookBase : IWinHook
    {
        #region [-- IMPLEMENTED INTERFACES --]

        /// <summary>
        ///     The main hook procedure.  This will be executed by the operating system when the hook is called.
        /// </summary>
        public abstract WinHookProcedure MainProcedure { get; protected set; }

        /// <summary>
        ///     The ID of this hook. Points to the <see cref="MainProcedure" />'s location in unmanaged memory.
        /// </summary>
        public abstract int HookId { get; set; }

        /// <summary>
        ///     The <see cref="WinHookType" /> of this hook.
        /// </summary>
        public abstract WinHookType HookType { get; }

        #endregion


        #region [-- IMPLEMENTED INTERFACES --]

        /// <summary>
        ///     Detaches the hook form the operating system.
        /// </summary>
        /// <returns>Whether or not the detach was successful.</returns>
        public virtual bool Detach()
        {
            if (this.Attached && WinHookUtility.DetachWinHook(this))
            {
                this.Attached = false;
            }

            return !this.Attached;
        }

        /// <summary>
        ///     Disposes the hook and its <see cref="MainProcedure" /> and detaches it from the OS.
        /// </summary>
        /// <exception cref="WinHookException">Thrown if <see cref="Detach" /> fails for some reason.</exception>
        public virtual void Dispose()
        {
            if (this.Attached && !this.Detach())
            {
                var innerException = new WinSysException($"Error detaching {this}");
                throw new WinHookException(
                    this,
                    $"Hook \"{this}\" faulted during dispose: {typeof(WinSysErrorCodes).GetMemberAttribute<DisplayValueAttribute>(innerException.ErrorCode.ToString())}",
                    innerException);
            }

            this.MainProcedure = null;
        }

        /// <summary>
        ///     Determines whether or not the hook has been registered.
        /// </summary>
        /// <remarks>
        ///     Based on the <see cref="HookId" />: if the value is 0, the hook is not registered; otherwise, it is. This can
        ///     also be set by sub-instances, but only to a false value.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown if the user attempts to set it to a "true" value manually.</exception>
        public bool Attached
        {
            get { return this.HookId != 0; }
            protected set
            {
                if (value)
                {
                    throw new ArgumentException("Unable to manually set a hook as attached without a valid hook ID!");
                }

                this.HookId = 0;
            }
        }

        #endregion


        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Gets the string representation of this hook.
        /// </summary>
        /// <remarks>Formts as "<see cref="HookType" />:{<see cref="HookId" />, <see cref="MainProcedure" />.GetHashCode()}</remarks>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.HookType}:{{{this.HookId}, {this.MainProcedure.GetHashCode()}}}";
        }

        #endregion


        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Calls the next hook in the call chain.
        /// </summary>
        /// <param name="nCode">Hook-specific parameter information.</param>
        /// <param name="wParam">Hook-specific message or flag.</param>
        /// <param name="lParam">Hook-specific message or flag.</param>
        /// <returns>The next hook's execution result code.</returns>
        protected virtual int CallNextHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return WinHookUtility.CallNextHookEx(this.HookType, nCode, wParam, lParam);
        }

        /// <summary>
        ///     Is the specified <see cref="WinHookCode" /> able to be handled by the hook?
        /// </summary>
        /// <param name="nCode">The nCode to check.</param>
        /// <returns></returns>
        protected virtual bool CanHookHandle(WinHookCode nCode)
        {
            return true;
        }

        #endregion


        #region [-- FIELDS --]

        /// <summary>
        ///     Unmanaged 4-bit bool compliant numerical value for <see cref="Boolean.False" />
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)] protected const byte False = 0;
        /// <summary>
        ///     Unmanaged 4-bit bool compliant numerical value for <see cref="Boolean.True" />
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)] protected const byte True = 1;

        #endregion
    }
}
