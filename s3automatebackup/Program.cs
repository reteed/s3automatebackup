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
            DateTime nextDate = selectedDate;

            switch (periodKey)
            {
                case 1: // Diario
                    nextDate = currentDate.Date.AddHours(selectedDate.Hour).AddMinutes(selectedDate.Minute);
                    if (currentDate >= nextDate)
                    {
                        nextDate = nextDate.AddDays(1);
                    }
                    break;
                case 2: // Mensual
                    nextDate = new DateTime(currentDate.Year, currentDate.Month, selectedDate.Day, selectedDate.Hour, selectedDate.Minute, 0);
                    if (currentDate >= nextDate || nextDate.Day != selectedDate.Day) // Si ya pasó o no es posible (ej. 30 de febrero)
                    {
                        nextDate = nextDate.AddMonths(1);
                        // Corrige el día si es necesario (ej. 31 en un mes que no lo tiene)
                        int daysInMonth = DateTime.DaysInMonth(nextDate.Year, nextDate.Month);
                        nextDate = new DateTime(nextDate.Year, nextDate.Month, Math.Min(daysInMonth, selectedDate.Day), selectedDate.Hour, selectedDate.Minute, 0);
                    }
                    break;
                case 3: // Anual
                    nextDate = new DateTime(currentDate.Year, selectedDate.Month, selectedDate.Day, selectedDate.Hour, selectedDate.Minute, 0);
                    if (currentDate >= nextDate)
                    {
                        nextDate = nextDate.AddYears(1);
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid period key");
            }

            TimeSpan interval = nextDate - currentDate;
            return interval.TotalMilliseconds;
        }

        private static void SetStartup()
        {
            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            startupKey.SetValue("S3AutomateBackup", $"\"{Application.ExecutablePath}\" -startup");
        }
    }
}