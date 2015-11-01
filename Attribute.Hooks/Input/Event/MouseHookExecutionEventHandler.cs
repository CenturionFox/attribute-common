namespace Attribute.Hooks.Windows.Input.Event
{
    /// <summary>
    ///     Handles the execution event of the <see cref="MouseHook" />.
    /// </summary>
    /// <param name="sender">The <see cref="MouseHook" /> that sent this event.</param>
    /// <param name="e">The event arguments.</param>
    /// <returns>A boolean determining whether or not the mouse event was catured or not.</returns>
    public delegate bool MouseHookExecutionEventHandler(MouseHook sender, MouseHookExecutionEventArgs e);
}
