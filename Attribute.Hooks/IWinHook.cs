using System;

namespace Attribute.Hooks.Windows
{
    /// <summary>
    ///     Models a Windows hook wrapper object.
    /// </summary>
    public interface IWinHook : IDisposable
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Detaches the hook from the operating system.
        /// </summary>
        /// <returns>Whether or not the detach was successful.</returns>
        bool Detach();

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     Used to determine whether or not the main procedure of this hook has been registered.
        /// </summary>
        bool Attached { get; }

        /// <summary>
        ///     The ID of this hook. Points to the <see cref="MainProcedure" />'s location in unmanaged memory.
        /// </summary>
        int HookId { get; set; }

        /// <summary>
        ///     The <see cref="WinHookType" /> of this hook.
        /// </summary>
        WinHookType HookType { get; }

        /// <summary>
        ///     The main hook procedure.  This will be executed by the operating system when the hook is called.
        /// </summary>
        WinHookProcedure MainProcedure { get; }

        #endregion
    }
}
