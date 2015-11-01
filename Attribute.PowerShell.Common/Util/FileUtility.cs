using System;
using System.IO;
using System.Management.Automation;
using Microsoft.PowerShell.Commands;

namespace Attribute.PowerShell.Common.Util
{
    public static class FileUtility
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        public static void ValidateDirectory(ProviderInfo provider, string directory)
        {
            validateFileSystemPath(provider, directory);

            if (!Directory.Exists(directory))
            {
                Exception exception;

                if (File.Exists(directory))
                {
                    exception = new InvalidOperationException($"{directory} is not a directory.");
                    ExceptionHelper.SetUpException(
                                                   ref exception,
                                                   ERR_NO_DIRECTORY,
                                                   ErrorCategory.InvalidOperation,
                                                   directory);
                }
                else
                {
                    exception =
                        new FileNotFoundException(
                            $"The directory {directory} could not be found.");
                    ExceptionHelper.SetUpException(
                                                   ref exception,
                                                   ERR_NO_DIRECTORY,
                                                   ErrorCategory.InvalidData,
                                                   directory);
                }

                throw exception;
            }
        }

        #endregion


        #region [-- PRIVATE METHODS --]

        private static bool isFileSystemPath(ProviderInfo provider)
        {
            return provider.ImplementingType == typeof(FileSystemProvider);
        }

        private static void validateFileSystemPath(ProviderInfo provider, string directory)
        {
            if (!isFileSystemPath(provider))
            {
                Exception exception = new ArgumentException("The syntax of the command is incorrect.");
                ExceptionHelper.SetUpException(
                                               ref exception,
                                               ERR_BAD_PROVIDER,
                                               ErrorCategory.InvalidArgument,
                                               directory);
                throw exception;
            }
        }

        #endregion


        #region [-- FIELDS --]

        private const string ERR_NO_DIRECTORY = "NoSuchDirectory";
        private const string ERR_BAD_PROVIDER = "InvalidProvider";

        #endregion
    }
}
