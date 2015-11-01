using Attribute.Hooks.Windows.Interop;

namespace Attribute.Hooks.Windows.Codes
{
    /// <summary>
    ///     Hook state codes for Computer Based Training hook events.
    /// </summary>
    public enum WinHookCbtCode
    {
        /// <summary>
        ///     The system is about to activate a window.
        /// </summary>
        Activate = 5,

        /// <summary>
        ///     The system has removed a mouse message from the system message queue. Upon receiving this hook code, a CBT
        ///     application must install a hook of type <see cref="WinHookType.JournalPlayback" /> in response to the mouse
        ///     message.
        /// </summary>
        ClickSkipped = 6,

        /// <summary>
        ///     A window is about to be created. The system calls the hook procedure before sending the WM_CREATE or WM_NCCREATE
        ///     message to the window. If the hook procedure returns true, the system destroys the window; the CreateWindow
        ///     function returns NULL, but the WM_DESTROY message is not sent to the window. If the hook procedure returns zero,
        ///     the window is created normally.
        ///     At the time of the <see cref="CreateWindow" /> notification, the window has been created, but its
        ///     final size and position may not have been determined and its parent window may not have been established. It is
        ///     possible to send messages to the newly created window, although it has not yet received WM_NCCREATE or WM_CREATE
        ///     messages. It is also possible to change the position in the z-order of the newly created window by modifying the
        ///     <see cref="SetWindowPositionFlags" /> member of the CBT_CREATEWND structure.
        /// </summary>
        // TODO RELATED PROCEDURE MUST RETURN TRUE OR FALSE [return: MarshalAs(UnmanagedType.Bool)]
        CreateWindow = 3,

        /// <summary>
        ///     A window is about to be destroyed.
        /// </summary>
        DestroyWindow = 4,

        /// <summary>
        ///     The system has removed a keyboard message from the system message queue. Upon receiving this hook code, a CBT
        ///     application must install a hook of type <see cref="WinHookType.JournalPlayback" /> in response to the keyboard
        ///     message.
        /// </summary>
        KeySkipped = 7,

        /// <summary>
        ///     A window is about to be minimized or maximized.
        /// </summary>
        MinMax = 1,

        /// <summary>
        ///     A window is about to be moved or sized.
        /// </summary>
        MoveSize = 0,

        /// <summary>
        ///     The system has retrieved a WM_QUEUESYNC message from the system message queue.
        /// </summary>
        QueueSync = 2,

        /// <summary>
        ///     A window is about to receive the keyboard focus.
        /// </summary>
        SetFocus = 9,

        /// <summary>
        ///     A system command is about to be carried out. This allows a CBT application to prevent task switching by means of
        ///     hot keys.
        /// </summary>
        SysCommand = 8
    }
}
