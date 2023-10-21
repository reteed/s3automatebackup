using Microsoft.Win32;
using s3automatebackup;

namespace S3AutomateBackup
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Force the application to start with Windows
            SetStartup();
            System.Threading.Thread.Sleep(5000);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("-startup"))
            {
                ScheduleBackup();
            }
            Application.Run(new AppApplicationContext());
        }

        private static void ScheduleBackup()
        {
            SecureFormStorage storage = new();
            string loadedData = storage.LoadFormFields();
            if (loadedData != null)
            {
                string[] fieldValues = loadedData.Split(',');
                S3Uploader uploader = new S3Uploader(fieldValues[0], fieldValues[1], fieldValues[2], fieldValues[3]);
                double intervalMilliseconds = GetIntervalFromPeriod(Convert.ToInt32(fieldValues[5]) - 1);
                BackupManager backupManager = new BackupManager(fieldValues[4], uploader, intervalMilliseconds);
            }
        }

        public static double GetIntervalFromPeriod(int periodKey)
        {
            switch (periodKey)
            {
                case 1: // Daily
                    return TimeSpan.FromSeconds(120).TotalMilliseconds;
                case 2: // Weekly
                    return TimeSpan.FromDays(7).TotalMilliseconds;
                case 3: // Monthly (assuming 30 days for simplicity)
                    return TimeSpan.FromDays(30).TotalMilliseconds;
                default:
                    throw new ArgumentException("Invalid period key");
            }
        }

        private static void SetStartup()
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            startupKey.SetValue("S3AutomateBackup", $"{Application.ExecutablePath.ToString()} -startup");
        }
    }
}