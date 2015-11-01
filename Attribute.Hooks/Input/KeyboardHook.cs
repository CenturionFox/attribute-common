using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Attribute.Hooks.Windows.Codes;
using Attribute.Hooks.Windows.Input.Event;

namespace Attribute.Hooks.Windows.Input
{
    public sealed class KeyboardHook : WinHookBase
    {
        #region [-- PRIVATE METHODS --]

        [return: MarshalAs(UnmanagedType.Bool)]
        private int keyboardHookMainProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var keyboardHookCode = (WinHookCode)nCode;
            var keys = (Keys)wParam;
            var keyboardHookStructure = new KeyboardHookStructure(lParam.ToInt32());

            if (keyboardHookCode == WinHookCode.Action || keyboardHookCode == WinHookCode.NoRemove)
            {
                if (this.HookExecution != null)
                {
                    if (this.HookExecution(
                                           this,
                                           new KeyboardHookExecutionEventArgs(
                                               keyboardHookCode,
                                               keys,
                                               keyboardHookStructure)))
                    {
                        return True;
                    }
                }
            }

            return this.CallNextHook(nCode, wParam, lParam);
        }

        #endregion


        #region [-- EVENT HANDLERS --]

        public event KeyboardHookExecutionEventHandler HookExecution;

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The hook's ID, a pointer to the main procedure in memory.
        /// </summary>
        public override int HookId
        {
            get { return this._hookId; }
            set { this._hookId = value; }
        }

        /// <summary>
        ///     <see cref="WinHookType.Keyboard" />, the <see cref="WinHookType" /> of this hook.
        /// </summary>
        public override WinHookType HookType => WinHookType.Keyboard;

        public override WinHookProcedure MainProcedure
        {
            get { return this._mainProcedure ?? (this._mainProcedure = this.keyboardHookMainProcedure); }
            protected set { this._mainProcedure = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private int _hookId;
        private WinHookProcedure _mainProcedure;

        #endregion
    }
}
