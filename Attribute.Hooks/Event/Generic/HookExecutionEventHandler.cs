namespace Attribute.Hooks.Windows.Event.Generic
{
    /// <summary>
    ///     Event that can be used with generic hook execution.
    /// </summary>
    /// <typeparam name="TWParam">The WORD parameter that was passed to and / or marshaled from the hook.</typeparam>
    /// <typeparam name="TLParam">The LONG parameter that was passed to and / or marshaled from the hook.</typeparam>
    /// <typeparam name="TReturn">The return type. Covariant.</typeparam>
    /// <param name="sender">The hook that fired the execution event.</param>
    /// <param name="e">The event arguments.</param>
    /// <returns>The hook execution result code.</returns>
    public delegate TReturn HookExecutionEventHandler<TWParam, TLParam, out TReturn>(
        WinHookBase sender,
        HookExecutionEventArgs<TWParam, TLParam> e);
}
