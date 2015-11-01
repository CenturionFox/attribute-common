using System;
using System.Management.Automation;

namespace Attribute.PowerShell.Common.Util
{
    public static class ExceptionHelper
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        public static void SetUpException(ref Exception exception, string errorCode, ErrorCategory errorCategory,
                                          object target)
        {
            exception.Data[ERROR_CODE] = errorCode;
            exception.Data[ERROR_CATEGORY] = errorCategory;
            exception.Data[ERROR_TARGET] = target;
        }

        public static ErrorRecord WriteException(this Cmdlet cmdlet, Exception ex, bool isTerminating = false)
        {
            var errorCode = "Unknown";
            var errorCategory = ErrorCategory.NotSpecified;
            object targetObj = null;

            if (ex.Data.Contains(ERROR_CODE))
            {
                errorCode = ex.Data[ERROR_CODE].ToString();
            }

            if (ex.Data.Contains(ERROR_CATEGORY))
            {
                errorCategory = (ex.Data[ERROR_CATEGORY] as ErrorCategory?).GetValueOrDefault();
            }

            if (ex.Data.Contains(ERROR_TARGET))
            {
                targetObj = ex.Data[ERROR_TARGET];
            }

            var err = new ErrorRecord(ex, errorCode, errorCategory, targetObj);

            if (isTerminating)
            {
                cmdlet.ThrowTerminatingError(err);
            }
            else
            {
                cmdlet.WriteError(err);
            }

            return err;
        }

        #endregion


        #region [-- FIELDS --]

        private const string ERROR_CODE = "ps_error_code";
        private const string ERROR_CATEGORY = "ps_error_category";
        private const string ERROR_TARGET = "ps_error_target";

        #endregion
    }
}
