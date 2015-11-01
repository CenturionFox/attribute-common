namespace Attribute.Hooks.Windows.Codes
{
    /// <summary>
    ///     Windows Message Framework hook state codes.
    /// </summary>
    public enum WinHookMessageCode
    {
        /// <summary>
        ///     The input event occurred while the Dynamic Data Exchange Management Library was waiting for a synchronous
        ///     transaction to finish.
        /// </summary>
        DynamicDataExchangeManager = 32769,

        /// <summary>
        ///     The input event occurred in a message box or dialog box.
        /// </summary>
        DialogBox = 0,

        /// <summary>
        ///     The input event occurred in a menu.
        /// </summary>
        Menu = 2,

        /// <summary>
        ///     The input event occurred in a scroll bar.
        /// </summary>
        ScrollBar = 5
    }
}
