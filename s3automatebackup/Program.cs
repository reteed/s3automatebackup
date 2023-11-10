using Microsoft.Win32;
using s3automatebackup.Services;

namespace s3automatebackup
{
    internal static class Program
    {
        private static BackupService _backupService;
        [STAThread]
        static void Main()
        {
            // Force the application to start with Windows
            SetStartup();
            ApplicationConfiguration.Initialize();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("-startup"))
            {
                ScheduleBackups();
            }
            Application.Run(new AppApplicationContext());
        }

        private static void SetStartup()
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            startupKey.SetValue("S3AutomateBackup", $"\"{Application.ExecutablePath}\" -startup");
        }

        private static void ScheduleBackups()
        {
            // Initialize the BackupService
            _backupService = new BackupService();

            // Schedule the backup tasks
            _backupService.ScheduleTasks();

            // It's important to keep a reference to _backupService so it's not garbage collected
            // This can be done by making it a static field or property in the Program class
        }
    }
}