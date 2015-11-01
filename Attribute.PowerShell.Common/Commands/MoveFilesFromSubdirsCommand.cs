using System;
using System.IO;
using System.Management.Automation;
using Attribute.PowerShell.Common.Util;

namespace Attribute.PowerShell.Common.Commands
{
    /// <summary>
    ///     Collapses file structure into the specified directory
    /// </summary>
    /// <remarks>
    ///     Recursively parses all files in all subdirectories from the given directory and moves them into the destination.
    ///     Also optionally cleans up the empty folders.
    /// </remarks>
    [Cmdlet(VerbsCommon.Move, "FilesFromSubdirs", SupportsShouldProcess = true)]
    public class MoveFilesFromSubdirsCommand : PSCmdlet
    {
        #region [-- PUBLIC & PROTECTED METHODS --]

        protected override void BeginProcessing()
        {
            try
            {
                ProviderInfo sourceProvider;
                PSDriveInfo sourceDriveInfo;
                var sourceDirectory = this.SessionState.Path.GetUnresolvedProviderPathFromPSPath(
                                                                                                 this.Source,
                                                                                                 out sourceProvider,
                                                                                                 out sourceDriveInfo);

                FileUtility.ValidateDirectory(sourceProvider, sourceDirectory);

                if (!string.IsNullOrWhiteSpace(this.Destination))
                {
                    ProviderInfo destinationProvider;
                    PSDriveInfo destinationDriveInfo;
                    var destinationDirectory = this.SessionState.Path.GetUnresolvedProviderPathFromPSPath(
                                                                                                          this.
                                                                                                              Destination,
                                                                                                          out
                                                                                                              destinationProvider,
                                                                                                          out
                                                                                                              destinationDriveInfo);
                    if (destinationDirectory.StartsWith(sourceDirectory))
                    {
                        throw new InvalidOperationException(
                            "The destination directory cannot be a subdirectory of the source directory.");
                    }

                    try
                    {
                        FileUtility.ValidateDirectory(destinationProvider, destinationDirectory);
                    }
                    catch (FileNotFoundException)
                    {
                        this.WriteVerbose($"Must create output directory: {destinationDirectory}");
                        var dInfo = new DirectoryInfo(destinationDirectory)
                                    {
                                        Attributes = FileAttributes.Normal
                                    };

                        dInfo.Create();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.SetUpException(
                                               ref ex,
                                               "InvalidDirectory",
                                               ErrorCategory.InvalidOperation,
                                               this.ToString());

                this.WriteException(ex, true);
            }
        }

        #endregion


        #region [-- PROPERTIES --]

        [Parameter, Alias("Cp")]
        public SwitchParameter CopyFiles
        {
            get { return this._copyFiles; }
            set { this._copyFiles = value; }
        }

        /// <summary>
        ///     The destination directory. Defaults to the source directory. If the destination does not exist, it will be created.
        ///     THIS SHOULD NEVER BE A SUBDIRECTORY OF <see cref="Source" />.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1)]
        public string Destination
        {
            get { return this._destination; }
            set { this._destination = value; }
        }

        [Parameter, Alias("Delete", "RemoveEmptyDirs")]
        public SwitchParameter RemoveEmptyDirectories
        {
            get { return this._removeEmptyDirectories; }
            set { this._removeEmptyDirectories = value; }
        }

        /// <summary>
        ///     The source directory.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0), Alias("Directory")]
        public string Source
        {
            get { return this._source; }
            set { this._source = value; }
        }

        /// <summary>
        ///     Suppresses warnings, such as duplicate files and the "Are You Sure" messages.
        /// </summary>
        [Parameter]
        public SwitchParameter SuppressWarnings
        {
            get { return this._suppressWarnings; }
            set { this._suppressWarnings = value; }
        }

        #endregion


        #region [-- FIELDS --]

        private SwitchParameter _copyFiles;
        private string _destination;
        private SwitchParameter _removeEmptyDirectories;
        private string _source;
        private SwitchParameter _suppressWarnings;

        #endregion
    }
}
