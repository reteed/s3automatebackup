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
                    S3Service s3Service = new S3Service(fieldValues[0], fieldValues[1], fieldValues[2], fieldValues[3]);
                    double intervalMilliseconds = GetIntervalFromNextOccurrence(Convert.ToInt32(fieldValues[5]), Convert.ToDateTime(fieldValues[6]));
                    BackupManager backupManager = new BackupManager(fieldValues[4], s3Service, intervalMilliseconds, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private static double GetIntervalFromNextOccurrence(int periodKey, DateTime selectedDate)
        {
            DateTime currentDate = DateTime.Now;
            DateTime nextDate;

            switch (periodKey)
            {
                case 1: // Daily
                    nextDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedDate.Hour, selectedDate.Minute, 0);
                    if (currentDate >= nextDate) // If the time has already passed for the selected date
                    {
                        nextDate = nextDate.AddDays(1); // Schedule for the same time on the next day
                    }
                    break;
                case 2: // Monthly
                    try
                    {
                        nextDate = new DateTime(currentDate.Year, currentDate.Month, selectedDate.Day, selectedDate.Hour, selectedDate.Minute, 0);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // This accounts for selecting dates like February 29 on non-leap years
                        nextDate = new DateTime(currentDate.Year, currentDate.Month + 1, 1).AddDays(-1);
                    }

                    if (currentDate >= nextDate) // If the date has already passed this month
                    {
                        nextDate = nextDate.AddMonths(1); // Schedule for the same date next month
                    }
                    break;

                case 3: // Yearly
                    nextDate = new DateTime(currentDate.Year, selectedDate.Month, selectedDate.Day, selectedDate.Hour, selectedDate.Minute, 0);

                    if (currentDate >= nextDate) // If the date has already passed this year
                    {
                        nextDate = nextDate.AddYears(1); // Schedule for the same date next year
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid period key");
            }

            TimeSpan interval = nextDate - currentDate; // Calculate the difference between the next date and now.
            return interval.TotalMilliseconds;
        }

        private static void SetStartup()
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            startupKey.SetValue("S3AutomateBackup", $"\"{Application.ExecutablePath}\" -startup");
        }
    }
}