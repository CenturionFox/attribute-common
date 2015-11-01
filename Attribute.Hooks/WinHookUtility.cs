using System;
using System.Runtime.InteropServices;

namespace Attribute.Hooks.Windows
{
    /// <summary>
    ///     Provides interop capabilities for windows message hooks.
    /// </summary>
    public static class WinHookUtility
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Registers the <see cref="hook" /> with the OS.
        /// </summary>
        /// <param name="hook">The hook to register.</param>
        /// <param name="global">Whether or not the registration is global. Defaults to false.</param>
        /// <returns>Whether or not the registration was successful.</returns>
        public static bool AttachWinHook<T>(ref T hook, bool global = false) where T : WinHookBase
        {
#pragma warning disable 618
            return AttachWinHook(ref hook, IntPtr.Zero, global ? 0 : AppDomain.GetCurrentThreadId());
#pragma warning restore 618
        }

        /// <summary>
        ///     Registers the <see cref="hook" /> with the OS.
        /// </summary>
        /// <param name="hook">The hook to attach.</param>
        /// <param name="hMod">A handle to the DLL containing the hook's MainProcedure.</param>
        /// <param name="global">Whether or not the registration is global. Defaults to false.</param>
        /// <returns>Whether or not the registration was successful.</returns>
        public static bool AttachWinHook<T>(ref T hook, IntPtr hMod, bool global = false) where T : WinHookBase
        {
#pragma warning disable 618
            return AttachWinHook(ref hook, hMod, global ? 0 : AppDomain.GetCurrentThreadId());
#pragma warning restore 618
        }

        /// <summary>
        ///     Registers the <see cref="hook" /> with the OS, associated with the thread specified by
        ///     <see cref="dwThreadId" />.
        /// </summary>
        /// <param name="hook">The hook to attach.</param>
        /// <param name="dwThreadId">The ID of the thread to associate with.</param>
        /// <returns>Whether or not the registration was successful.</returns>
        public static bool AttachWinHook<T>(ref T hook, int dwThreadId) where T : WinHookBase
        {
            return AttachWinHook(ref hook, IntPtr.Zero, dwThreadId);
        }

        /// <summary>
        ///     Registers the <see cref="hook" /> with the OS, associated with the thread specified by
        ///     <see cref="dwThreadId" />.
        /// </summary>
        /// <param name="hook">The hook to attach.</param>
        /// <param name="hMod">A handle to the DLL containing the hook's MainProcedure.</param>
        /// <param name="dwThreadId">The ID of the thread to associate with.</param>
        /// <returns>Whether or not the registration was successful.</returns>
        public static bool AttachWinHook<T>(ref T hook, IntPtr hMod, int dwThreadId) where T : WinHookBase
        {
            if (hook != null && !hook.Attached)
            {
                hook.HookId = SetWindowsHookEx(hook.HookType, hook.MainProcedure, hMod, dwThreadId);
            }
            else
            {
                throw new ArgumentException("Cannot attach " + hook + ": Already registered!");
            }

            return hook.Attached;
        }

        /// <summary>
        ///     Removes a <see cref="hook" />'s hook procedure from the hook chain.
        /// </summary>
        /// <param name="hook">The hook to detach.</param>
        /// <returns>Whether or not the unhook was successful.</returns>
        public static bool DetachWinHook(WinHookBase hook)
        {
            return UnhookWindowsHookEx(hook.HookId);
        }

        #endregion


        #region [-- P/INVOKE --]

        /// <summary>
        ///     Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this
        ///     function either before or after processing the hook information.
        /// </summary>
        /// <param name="idHook">The hook type ID. This parameter is ignored. See <see cref="WinHookType" /> for valid types.</param>
        /// <param name="nCode">
        ///     The hook code passed to the current hook procedure. The next hook procedure uses this code to
        ///     determine how to process the hook information.
        /// </param>
        /// <param name="wParam">
        ///     The wParam value passed to the current hook procedure. The meaning of this parameter depends on
        ///     the type of hook associated with the current hook chain.
        /// </param>
        /// <param name="lParam">
        ///     The lParam value passed to the current hook procedure. The meaning of this parameter depends on
        ///     the type of hook associated with the current hook chain.
        /// </param>
        /// <returns>
        ///     This value is returned by the next hook procedure in the chain. The current hook procedure must also return
        ///     this value. The meaning of the return value depends on the hook type.
        /// </returns>
        [DllImport("USER32.DLL", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,
            SetLastError = true)]
        internal static extern int CallNextHookEx(WinHookType idHook, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        ///     Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the
        ///     system for certain types of events. These events are associated either with a specific thread or with all threads
        ///     in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">The type of hook procedure to be installed. See <see cref="WinHookType" /> for valid types.</param>
        /// <param name="lpfn">
        ///     A pointer to the hook procedure. If the dwThreadId parameter is zero or specifies the identifier of
        ///     a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL. Otherwise,
        ///     lpfn can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hMod">
        ///     A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod
        ///     parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and if
        ///     the hook procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        ///     The identifier of the thread with which the hook procedure is to be associated. For desktop
        ///     apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same
        ///     desktop as the calling thread.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the handle to the hook procedure. If the function fails, the
        ///     return value is NULL. To get extended error information, call <see cref="WinSysUtility.GetLastErrorCode" />.
        /// </returns>
        [DllImport("USER32.DLL", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,
            SetLastError = true)]
        private static extern int SetWindowsHookEx(WinHookType idHook,
                                                   WinHookProcedure lpfn,
                                                   IntPtr hMod,
                                                   int dwThreadId);

        /// <summary>
        ///     Removes a hook procedure installed in a hook chain by the <see cref="SetWindowsHookEx" /> function.
        /// </summary>
        /// <param name="idHook">
        ///     A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to
        ///     <see cref="SetWindowsHookEx" />.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is true. If the function fails, the return value is false. To get
        ///     extended error information, call <see cref="WinSysUtility.GetLastErrorCode" />.
        /// </returns>
        [DllImport("USER32.DLL", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall,
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        #endregion
    }
}
