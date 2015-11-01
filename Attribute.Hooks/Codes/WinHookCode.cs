namespace Attribute.Hooks.Windows.Codes
{
    /// <summary>
    ///     Generic hook state codes.
    /// </summary>
    public enum WinHookCode
    {
        Action = 0,

        /// <summary>
        ///     The hook procedure must copy the current mouse or keyboard message to the EVENTMSG structure pointed to by the
        ///     lParam parameter.
        /// </summary>
        GetNext = 1,

        /// <summary>
        ///     An application has called the PeekMessage function with wRemoveMsg set to PM_NOREMOVE, indicating that the message
        ///     is not removed from the message queue after PeekMessage processing.
        /// </summary>
        NoRemove = 3,

        /// <summary>
        ///     The hook procedure must prepare to copy the next mouse or keyboard message to the EVENTMSG structure pointed to by
        ///     lParam. Upon receiving the <see cref="WinHookCode.GetNext" /> code, the hook procedure must copy the message to the
        ///     structure.
        /// </summary>
        Skip = 2,

        /// <summary>
        ///     A system-modal dialog box has been destroyed. The hook procedure must resume playing back the messages.
        /// </summary>
        SystemModalOff = 5,

        /// <summary>
        ///     A system-modal dialog box is being displayed. Until the dialog box is destroyed, the hook procedure must stop
        ///     playing back messages.
        /// </summary>
        SystemModalOn = 4
    }
}
