using System;
using Attribute.Common.Attributes;
using Attribute.Common.Attributes.Enumeration;

namespace Attribute.Hooks.Windows.Exceptions
{
    /// <summary>
    ///     Provides localized values for Win32 system errors raised by the kernel or operating system.
    /// </summary>
    public enum WinSysErrorCodes : short
    {
        /// <summary>
        ///     No errors occurred.
        /// </summary>
        [DisplayValue("Success"), DataValue("The operation completed successfully."),
         BoundExceptionType] Success = 0x0,

        /// <summary>
        ///     The specified pointer/handle was invalid.
        /// </summary>
        [DisplayValue("Invalid Handle"),
         DataValue("The specified handle was invalid."),
         BoundExceptionType(typeof(NullReferenceException))] InvalidHandle = 0x6,

        /// <summary>
        ///     The specified window handle was invalid.
        /// </summary>
        [DisplayValue("Invalid Window Handle"),
         DataValue("The specified window handle was invalid."),
         BoundExceptionType(typeof(NullReferenceException))] InvalidWindowHandle = 0x578,

        /// <summary>
        ///     The specified menu handle was invalid.
        /// </summary>
        [DisplayValue("Invalid Menu Handle"),
         DataValue("The specified menu handle was invalid."),
         BoundExceptionType(typeof(NullReferenceException))] InvalidMenuHandle = 0x579,

        /// <summary>
        ///     The specified hook handle was invalid.
        /// </summary>
        [DisplayValue("Invalid Hook Handle"),
         DataValue("The specified hook was not registered."),
         BoundExceptionType(typeof(WinHookException), new[]
                                                      {
                                                          typeof(WinHookBase),
                                                          typeof(string),
                                                          typeof(Exception)
                                                      })] InvalidHookHandle = 0x57c,

        /// <summary>
        ///     An unspecified error occurred.
        /// </summary>
        [DisplayValue("Unspecified Error"),
         DataValue("An unknown error occurred."),
         BoundExceptionType] Unspecified = 0x7fff
    }
}
