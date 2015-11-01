using System;
using System.Management.Automation;
using Attribute.PowerShell.Common.Properties;
using Attribute.PowerShell.Common.Util;
using Microsoft.PowerShell.Commands;

namespace Attribute.PowerShell.Common.Commands
{
    /// <summary>
    ///     Sets the location to a specified path and reports the results.
    /// </summary>
    /// <remarks>
    ///     Sets the current execution directory to a specified location
    ///     and displays information pertaining to where that location's absolute
    ///     path resides, as well as the relative path passed to the function
    ///     to navigate there.
    /// </remarks>
    [Cmdlet(VerbsCommon.Set, "LocationWithReport")]
    public class SetLocationWithReportCommand : ConsoleColorCmdlet
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        // Processes the command
        protected override void ProcessRecord()
        {
            var directoryPath = string.Join(" ", this.Destination);

            this.WriteVerbose(
                              string.Format(
                                            Resources.SetLocationWithReportCommand_DirectorySetNotify_Verbose,
                                            directoryPath));

            try
            {
                ProviderInfo provider;
                PSDriveInfo drive;
                var newCommandDir = this.SessionState.Path.GetUnresolvedProviderPathFromPSPath(
                                                                                               directoryPath,
                                                                                               out provider,
                                                                                               out drive);

                FileUtility.ValidateDirectory(provider, newCommandDir);
                this.SessionState.Path.SetLocation(newCommandDir);
                this.reportLocationChange();
            }
            catch (Exception ex)
            {
                this.WriteException(ex, true);
            }
        }

        #endregion


        #region [-- PRIVATE METHODS --]

        private void reportLocationChange()
        {
            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.ForegroundColor;

            var currentDir = this.SessionState.Path.CurrentLocation.Path;

            Console.WriteLine(Resources.SetLocationWithReportCommand_DirectorySetNotify, currentDir);

            Console.ResetColor();
        }

        #endregion


        #region [-- PROPERTIES --]

        /// <summary>
        ///     String representing the relative path to which to navigate.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromRemainingArguments = true, ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true), Alias("cd", "Directory")]
        public string[] Destination { get; set; }

        #endregion
    }
}
