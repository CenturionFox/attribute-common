using System;
using Attribute.Common.Attributes.Enumeration;
using Attribute.Common.Extensions;
using Attribute.Hooks.Windows.Interop;

namespace Attribute.Hooks.Windows.Exceptions
{
    /// <summary>
    ///     Wraps a system error code in an exception object.
    /// </summary>
    public sealed class WinSysException : Exception
    {
        #region [-- CONSTRUCTORS --]

        /// <summary>
        ///     Creates a new WinSysException from the last error code raised by the operating system.
        /// </summary>
        public WinSysException()
            : this(WinSysUtility.GetLastErrorCode())
        {
        }

        /// <summary>
        ///     Creates a new WinSysException with the specified message from the last error code raised by the operating system.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public WinSysException(string message)
            : this(WinSysUtility.GetLastErrorCode(), message)
        {
        }

        /// <summary>
        ///     Creates a new WinSysException with the specified message from the last error code raised by the operating system.
        ///     The Inner Exception is also set; however, this may be considered redundant as the exception is inherently raised by
        ///     a specific kernel fault.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception that caused this WinSysException to be thrown.</param>
        public WinSysException(string message, Exception innerException)
            : this(WinSysUtility.GetLastErrorCode(), message, innerException)
        {
        }

        /// <summary>
        ///     Creates a new WinSysException from the specified error code.  The message is automatically set to the SysErrorCode
        ///     <see cref="DisplayValueAttribute">Display</see> and <see cref="DataValueAttribute">Data</see>
        ///     attributes.
        /// </summary>
        /// <param name="errorCode">The error code of the system fault that raised this exception.</param>
        public WinSysException(WinSysErrorCodes errorCode)
            : base(
                $"{typeof(WinSysErrorCodes).GetMemberAttribute<DisplayValueAttribute>(errorCode.ToString())}: {typeof(WinSysErrorCodes).GetMemberAttribute<DataValueAttribute>(errorCode.ToString())}"
                )
        {
            this.addErrorData(errorCode);
        }

        /// <summary>
        ///     Creates a new WinSysException from the specified error code.  The message is specified by message.
        /// </summary>
        /// <param name="errorCode">The error code of the system fault that raised this exception.</param>
        /// <param name="message">The exception message.</param>
        public WinSysException(WinSysErrorCodes errorCode, string message)
            : base(message)
        {
            this.addErrorData(errorCode);
        }

        /// <summary>
        ///     Creates a new WinSysException from the specified error code.  The message is specified by message.
        ///     The Inner Exception is also set; however, this may be considered redundant as the exception is inherently raised
        ///     by a specific kernel fault.
        /// </summary>
        /// <param name="errorCode">The error code of the system fault that raised this exception.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception that caused this WinSysException to be thrown.</param>
        public WinSysException(WinSysErrorCodes errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.addErrorData(errorCode);
        }

        #endregion


        #region [-- PRIVATE METHODS --]

        private void addErrorData(WinSysErrorCodes errorCode)
        {
            this.ErrorCode = errorCode;

            this.Data.Add("errorCode", errorCode);
            this.Data.Add("errorCodeInternalName", errorCode.ToString());
            this.Data.Add("errorCodeValue", (short)errorCode);
            this.Data.Add(
                          "errorCodeDisplayName",
                          typeof(WinSysErrorCodes).GetMemberAttribute<DisplayValueAttribute>(errorCode.ToString()));
            this.Data.Add(
                          "errorCodeData",
                          typeof(WinSysErrorCodes).GetMemberAttribute<DataValueAttribute>(errorCode.ToString()));
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     The error code of the system fault that caused this exception to be thrown.
        /// </summary>
        public WinSysErrorCodes ErrorCode { get; private set; }

        #endregion
    }
}
