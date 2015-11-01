using System;

namespace Attribute.Hooks.Windows
{
    /// <summary>
    ///     Handles a call to a hook from the operating system.
    /// </summary>
    /// <param name="nCode">The last hook's execution result code.</param>
    /// <param name="wParam">A message parameter.</param>
    /// <param name="lParam">A message prarmeter.</param>
    /// <returns>The hook's execution result code.</returns>
    public delegate int WinHookProcedure(int nCode, IntPtr lParam, IntPtr wParam);
}
