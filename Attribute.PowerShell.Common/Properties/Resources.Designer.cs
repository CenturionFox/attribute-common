﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Attribute.PowerShell.Common.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Attribute.PowerShell.Common.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press any key to continue, or wait.
        /// </summary>
        internal static string LockExecutionCommand_Prompt {
            get {
                return ResourceManager.GetString("LockExecutionCommand_Prompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} {1} {2}....
        /// </summary>
        internal static string LockExecutionCommand_Prompt_Format {
            get {
                return ResourceManager.GetString("LockExecutionCommand_Prompt_Format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press any key to continue....
        /// </summary>
        internal static string LockExecutionCommand_Prompt_Indefinite {
            get {
                return ResourceManager.GetString("LockExecutionCommand_Prompt_Indefinite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please wait.
        /// </summary>
        internal static string LockExecutionCommand_Prompt_NoCancel {
            get {
                return ResourceManager.GetString("LockExecutionCommand_Prompt_NoCancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current Destination set to {0}..
        /// </summary>
        internal static string SetLocationWithReportCommand_DirectorySetNotify {
            get {
                return ResourceManager.GetString("SetLocationWithReportCommand_DirectorySetNotify", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Setting directory to {0}.
        /// </summary>
        internal static string SetLocationWithReportCommand_DirectorySetNotify_Verbose {
            get {
                return ResourceManager.GetString("SetLocationWithReportCommand_DirectorySetNotify_Verbose", resourceCulture);
            }
        }
    }
}
