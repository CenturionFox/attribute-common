using System.Diagnostics;
using Attribute.Common.Enumeration;

namespace Attribute.Common.Framework
{
    /// <summary>
    /// Models an Attribute Studios component.
    /// </summary>
    public interface IAttributeComponent
    {
        /// <summary>
        /// Gets the state of the component.
        /// </summary>
        /// <value>
        /// The state of the component.
        /// </value>
        AttributeComponentState ComponentState { get; }
    }
}
