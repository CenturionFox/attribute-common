using System;
using System.Runtime.InteropServices;
using Attribute.Hooks.Windows.Codes;
using Attribute.Hooks.Windows.Input.Event;
using Attribute.Hooks.Windows.Interop;
using Attribute.Hooks.Windows.Interop.Messages;

namespace Attribute.Hooks.Windows.Input
{
    /// <summary>
    ///     Wrapper class for a hook procedure that is called whenever the system sends a mouse message.
    /// </summary>
    public sealed class MouseHook : WinHookBase
    {
        #region [-- PRIVATE METHODS --]

        [return: MarshalAs(UnmanagedType.Bool)]
        private int mouseHookMainProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var mouseCode = (WinHookCode)nCode;

            var ptrToStructure = (MouseHookStructure)Marshal.PtrToStructure(lParam, typeof(MouseHookStructure));

            if (mouseCode == WinHookCode.Action || mouseCode == WinHookCode.NoRemove)
            {
                if (this.HookExecution != null)
                {
                    if (this.HookExecution(
                                           this,
                                           new MouseHookExecutionEventArgs(
                                               mouseCode,
                                               (MouseMessage)wParam,
                                               ptrToStructure)))
                    {
                        return True;
                    }
                }
            }

            return this.CallNextHook(nCode, wParam, lParam);
        }

        #endregion


        #region [-- EVENT HANDLERS --]

        /// <summary>
        ///     The custom procedure to be called when the hook is called.
        /// </summary>
        public event MouseHookExecutionEventHandler HookExecution;

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The hook ID.  This is a pointer to the hook procedure in unmanaged memory.
        /// </summary>
        public override int HookId
        {
            get { return this._hookId; }
            set { this._hookId = value; }
        }

        /// <summary>
        ///     <see cref="WinHookType.Mouse" />, the <see cref="WinHookType" /> of this hook.
        /// </summary>
        public override WinHookType HookType => WinHookType.Mouse;

        /// <summary>
        ///     The main procedure.  This is the procedure that the operating system will execute when the hook is called.
        /// </summary>
        public override WinHookProcedure MainProcedure
        {
            get { return this._mainProcedure ?? (this._mainProcedure = this.mouseHookMainProcedure); }
            protected set { this._mainProcedure = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private volatile int _hookId;
        private WinHookProcedure _mainProcedure;

        #endregion
    }
}
