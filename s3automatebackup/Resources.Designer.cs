﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace s3automatebackup {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("s3automatebackup.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Todos los archivos (.).
        /// </summary>
        internal static string AllFiles {
            get {
                return ResourceManager.GetString("AllFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Backup failed for configuration {0}..
        /// </summary>
        internal static string BackupFailed {
            get {
                return ResourceManager.GetString("BackupFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The backup failed for configuration {0} on bucket {1}. Reason: {2}..
        /// </summary>
        internal static string BackupFailedBody {
            get {
                return ResourceManager.GetString("BackupFailedBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Backup completed successfully..
        /// </summary>
        internal static string BackupSuccessMessage {
            get {
                return ResourceManager.GetString("BackupSuccessMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successful Backup.
        /// </summary>
        internal static string BackupSuccessSubject {
            get {
                return ResourceManager.GetString("BackupSuccessSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This configuration is currently in use by a backup task..
        /// </summary>
        internal static string ConfigurationInUse {
            get {
                return ResourceManager.GetString("ConfigurationInUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm Deletion.
        /// </summary>
        internal static string ConfirmDeletion {
            get {
                return ResourceManager.GetString("ConfirmDeletion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to delete version {0} of object {1}?.
        /// </summary>
        internal static string ConfirmDeletionVersion {
            get {
                return ResourceManager.GetString("ConfirmDeletionVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The decryption was canceled..
        /// </summary>
        internal static string DecryptionCancelled {
            get {
                return ResourceManager.GetString("DecryptionCancelled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file could not be decrypted..
        /// </summary>
        internal static string DecryptionFailed {
            get {
                return ResourceManager.GetString("DecryptionFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to delete all the objects in the bucket?.
        /// </summary>
        internal static string DeleteAllObjects {
            get {
                return ResourceManager.GetString("DeleteAllObjects", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove this setting?.
        /// </summary>
        internal static string DeleteConfigurationConfirm {
            get {
                return ResourceManager.GetString("DeleteConfigurationConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to delete this task?.
        /// </summary>
        internal static string DeleteTaskConfirm {
            get {
                return ResourceManager.GetString("DeleteTaskConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removal completed successfully..
        /// </summary>
        internal static string DeletionCompleted {
            get {
                return ResourceManager.GetString("DeletionCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Download completed successfully..
        /// </summary>
        internal static string DownloadCompleted {
            get {
                return ResourceManager.GetString("DownloadCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file could not be downloaded..
        /// </summary>
        internal static string DownloadFailed {
            get {
                return ResourceManager.GetString("DownloadFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Encryption was cancelled..
        /// </summary>
        internal static string EncryptionCancelled {
            get {
                return ResourceManager.GetString("EncryptionCancelled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Por favor, ingrese una clave privada válida..
        /// </summary>
        internal static string EnterValidPrivateKey {
            get {
                return ResourceManager.GetString("EnterValidPrivateKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error.
        /// </summary>
        internal static string Error {
            get {
                return ResourceManager.GetString("Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exit.
        /// </summary>
        internal static string Exit {
            get {
                return ResourceManager.GetString("Exit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The selected date and time must be in the future..
        /// </summary>
        internal static string InvalidDateSelection {
            get {
                return ResourceManager.GetString("InvalidDateSelection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid period key..
        /// </summary>
        internal static string InvalidPeriodKey {
            get {
                return ResourceManager.GetString("InvalidPeriodKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid SMTP port. Please enter a valid number..
        /// </summary>
        internal static string InvalidPort {
            get {
                return ResourceManager.GetString("InvalidPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a bucket before saving..
        /// </summary>
        internal static string MissingBucket {
            get {
                return ResourceManager.GetString("MissingBucket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please create at least one configuration before creating a task..
        /// </summary>
        internal static string MissingConfigurations {
            get {
                return ResourceManager.GetString("MissingConfigurations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please complete all information before sending a test email..
        /// </summary>
        internal static string MissingInformation {
            get {
                return ResourceManager.GetString("MissingInformation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open.
        /// </summary>
        internal static string Open {
            get {
                return ResourceManager.GetString("Open", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operation cancelled..
        /// </summary>
        internal static string OperationCancelled {
            get {
                return ResourceManager.GetString("OperationCancelled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Question.
        /// </summary>
        internal static string QuestionTitle {
            get {
                return ResourceManager.GetString("QuestionTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully deleted old files and versions from bucket {0}..
        /// </summary>
        internal static string RemoveOldFilesMessage {
            get {
                return ResourceManager.GetString("RemoveOldFilesMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please complete all required fields..
        /// </summary>
        internal static string RequiredFieldsMissing {
            get {
                return ResourceManager.GetString("RequiredFieldsMissing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save file as.
        /// </summary>
        internal static string SaveFileAs {
            get {
                return ResourceManager.GetString("SaveFileAs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you want to select a folder? (Yes = Folder, No = File).
        /// </summary>
        internal static string SelectPathType {
            get {
                return ResourceManager.GetString("SelectPathType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select a valid version..
        /// </summary>
        internal static string SelectValidVersion {
            get {
                return ResourceManager.GetString("SelectValidVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The test email could not be sent..
        /// </summary>
        internal static string SmtpFailure {
            get {
                return ResourceManager.GetString("SmtpFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Test email sent successfully..
        /// </summary>
        internal static string SmtpSuccess {
            get {
                return ResourceManager.GetString("SmtpSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SMTP Test Email.
        /// </summary>
        internal static string SmtpTest {
            get {
                return ResourceManager.GetString("SmtpTest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This is a test email to verify SMTP settings..
        /// </summary>
        internal static string SmtpTestMessage {
            get {
                return ResourceManager.GetString("SmtpTestMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Success.
        /// </summary>
        internal static string Success {
            get {
                return ResourceManager.GetString("Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Version {0} of object {1} was successfully deleted..
        /// </summary>
        internal static string VersionDeletedSuccess {
            get {
                return ResourceManager.GetString("VersionDeletedSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning.
        /// </summary>
        internal static string Warning {
            get {
                return ResourceManager.GetString("Warning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning.
        /// </summary>
        internal static string WarningTitle {
            get {
                return ResourceManager.GetString("WarningTitle", resourceCulture);
            }
        }
    }
}
