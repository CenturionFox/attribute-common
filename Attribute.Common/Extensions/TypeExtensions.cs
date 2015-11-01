using System;
using System.Linq;

namespace Attribute.Common.Extensions
{
    /// <summary>
    ///     Provides utilities for determining member or class attributes via reflection.
    /// </summary>
    public static class TypeExtensions
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Gets a member attribute of type T for a member with the given name <see cref="memberName" /> in the type
        ///     <see cref="type" />. Extension method for <see cref="System.Type" />.
        /// </summary>
        /// <typeparam name="T">The type of the attribute to get.</typeparam>
        /// <param name="type">The type in which the specified member resides.</param>
        /// <param name="memberName">The name of the member from which the attribute should be obtained.</param>
        /// <returns>
        ///     An attribute of type <see cref="T" /> if such an attribute is defined; otherwise, null.
        /// </returns>
        public static T GetMemberAttribute<T>(this Type type, string memberName) where T : System.Attribute
        {
            var memberInfo = type.GetMember(memberName);

            return memberInfo.Length <= 0
                       ? null
                       : memberInfo.SelectMany(pMember => pMember.GetCustomAttributes(typeof(T), false)).
                                    OfType<T>().
                                    FirstOrDefault();
        }

        #endregion
    }
}
