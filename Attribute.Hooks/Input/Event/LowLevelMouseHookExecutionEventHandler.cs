namespace Attribute.Hooks.Windows.Input.Event
{
    /// <summary>
    ///     Handles the execution event of the <see cref="LowLevelMouseHook" />.
    /// </summary>
    /// <param name="sender">The <see cref="LowLevelMouseHook" /> that sent this event.</param>
    /// <param name="e">The event arguments.</param>
    /// <returns>A boolean determining whether or not the mouse event was catured or not.</returns>
    public delegate bool LowLevelMouseHookExecutionEventHandler(
        LowLevelMouseHook sender,
        LowLevelMouseHookExecutionEventArgs e);
}
