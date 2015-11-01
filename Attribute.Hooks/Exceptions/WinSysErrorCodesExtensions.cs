using System;
using System.Reflection;
using Attribute.Common.Attributes;
using Attribute.Common.Extensions;

namespace Attribute.Hooks.Windows.Exceptions
{
    /// <summary>
    ///     Provides extensions for the <see cref="WinSysErrorCodes" /> enum.
    /// </summary>
    public static class WinSysErrorCodesExtensions
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        /// <summary>
        ///     Generates an exception from the <see cref="WinSysErrorCodes" /> <see cref="BoundExceptionTypeAttribute" />
        ///     information.
        /// </summary>
        /// <param name="code">The SysErrorCodes value from which to generate the bound exception.</param>
        /// <param name="exceptionInitParams">Initialization parameters for the bound exception.</param>
        /// <returns>An exception generated from the SysErrorCodes value.</returns>
        public static Exception GenerateBoundException(this WinSysErrorCodes code, params object[] exceptionInitParams)
        {
            // TODO Full implementation of BoundExceptionTypeAttribute.InitParamTypes list in SysErrorCodesExtensions.GenerateBoundException
            var boundExceptionAttribute =
                typeof(WinSysErrorCodes).GetMemberAttribute<BoundExceptionTypeAttribute>(code.ToString());
            Exception boundException = null;

            var t = boundExceptionAttribute?.BoundExceptionType;

            if (t == null)
            {
                return null;
            }

            var tConstructor = t.GetConstructor(
                                                BindingFlags.Public,
                                                null,
                                                boundExceptionAttribute.InitParamTypes,
                                                null);

            if (tConstructor != null)
            {
                try
                {
                    boundException = tConstructor.Invoke(exceptionInitParams) as Exception;
                }
                catch (TypeInitializationException)
                {
                }
            }
            else
            {
                throw new MissingMethodException("The specified constructor did not exist.");
            }

            return boundException;
        }

        #endregion
    }
}
