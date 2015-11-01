namespace Attribute.Hooks.Windows.Event
{
    /// <summary>
    ///     Dynamic event handler for a hook execution event.
    /// </summary>
    /// <param name="sender">The hook that fired the execution event.</param>
    /// <param name="e">The event arguments.</param>
    /// <returns>A dynamic object that will determine the hook event's execution result.</returns>
    public delegate dynamic HookExecutionEventHandler(WinHookBase sender, HookExecutionEventArgs e);
}
