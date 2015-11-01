using System;

namespace Attribute.Hooks.Windows
{
    [Flags]
    public enum HookInjectionFlags
    {
        None = 0,
        LowerIntegrityLevelInjected = 1,
        Injected = 2
    }
}
