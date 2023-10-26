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
            try
            {
                // Force the application to start with Windows
                SetStartup();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ScheduleBackup()
        {
            try
            {
                SecureFormStorage storage = new();
                string loadedData = storage.LoadFormFields();
                if (loadedData != null)
                {
                    string[] fieldValues = loadedData.Split(',');
                    S3Uploader uploader = new S3Uploader(fieldValues[0], fieldValues[1], fieldValues[2], fieldValues[3]);
                    double intervalMilliseconds = GetIntervalFromNextOccurrence(Convert.ToInt32(fieldValues[5]), Convert.ToDateTime(fieldValues[6]));
                    BackupManager backupManager = new BackupManager(fieldValues[4], uploader, intervalMilliseconds, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static double GetIntervalFromNextOccurrence(int periodKey, DateTime selectedDate)
        {
            DateTime nextDate;

            switch (periodKey)
            {
                case 1: // Daily
                    nextDate = selectedDate.AddDays(1);
                    break;

                case 2: // Monthly
                    nextDate = selectedDate.AddMonths(1);
                    break;

                case 3: // Yearly
                    nextDate = selectedDate.AddYears(1);
                    break;

                default:
                    throw new ArgumentException("Invalid period key");
            }

            TimeSpan interval = nextDate - DateTime.Now; // Calculate the difference between the next date and now.
            return interval.TotalMilliseconds;
        }

        private static void SetStartup()
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            startupKey.SetValue("S3AutomateBackup", $"\"{Application.ExecutablePath}\" -startup");
        }
    }
}