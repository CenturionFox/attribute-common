using System;

namespace Attribute.Common.Enumeration
{
    /// <summary>
    ///     Represents the state of an IComponent.
    /// </summary>
    [Flags]
    public enum AttributeComponentState : byte
    {
        /// <summary>
        ///     The normal state.
        /// </summary>
        Normal,

        /// <summary>
        ///     The errored state.
        /// </summary>
        Errored = 125
    }
}
