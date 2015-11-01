using System;

namespace Attribute.Hooks.Windows
{
    /// <summary>
    ///     Models a form that contains a hook.
    /// </summary>
    public interface IWinHookForm : IDisposable
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Registers the form's hooks with the operating system.
        /// </summary>
        void AttachHooks();

        /// <summary>
        ///     Deregisters the form's hooks from the operating system.
        /// </summary>
        /// <returns>True if the detach was successful, false if not.</returns>
        bool DetachHooks();

        #endregion
    }
}
