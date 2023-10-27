using s3automatebackup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace S3AutomateBackup
{
    public partial class ConfigurationForm : Form
    {
        private SecureFormStorage Storage = new();

        readonly Dictionary<int, string> Period = new Dictionary<int, string>
        {
            { 1, "Daily" },
            { 2, "Weekly" },
            { 3, "Monthly" },
        };

        public ConfigurationForm()
        {
            InitializeComponent();
            periodComboBox.DataSource = new BindingSource(Period, null);
            periodComboBox.DisplayMember = "Value"; // This displays the string part.
            periodComboBox.ValueMember = "Key";     // This is the underlying value, e.g. for when you want to know which int was selected.
            string loadedData = Storage.LoadFormFields();
            if (loadedData != null)
            {
                string[] fieldValues = loadedData.Split(',');
                serverTextBox.Text = fieldValues[0];
                accessKeyTextBox.Text = fieldValues[1];
                secretKeyTextBox.Text = fieldValues[2];
                bucketNameTextBox.Text = fieldValues[3];
                backupFolderTextBox.Text = fieldValues[4];
                periodComboBox.SelectedIndex = Convert.ToInt32(fieldValues[5]) - 1;
                dayDateTimePicker.Value = Convert.ToDateTime(fieldValues[6]);
            }
        }

        private void generateTaskButton_Click(object sender, EventArgs e)
        {
            S3Service s3Service = new S3Service(serverTextBox.Text, accessKeyTextBox.Text, secretKeyTextBox.Text, bucketNameTextBox.Text);
            int selectedKey = ((KeyValuePair<int, string>)periodComboBox.SelectedItem).Key;
            DateTime selectedDate = dayDateTimePicker.Value;
            if (!string.IsNullOrWhiteSpace(serverTextBox.Text) && !string.IsNullOrWhiteSpace(accessKeyTextBox.Text) && !string.IsNullOrWhiteSpace(secretKeyTextBox.Text) && !string.IsNullOrWhiteSpace(bucketNameTextBox.Text) && !string.IsNullOrWhiteSpace(backupFolderTextBox.Text))
            {
                if (selectedDate >= DateTime.Now)
                {
                    if (firstBackupCheckBox.Checked)
                    {
                        BackupManager backupManagerNow = new BackupManager(backupFolderTextBox.Text, s3Service, 5000, true);
                    }
                    double intervalMilliseconds = GetIntervalFromNextOccurrence(selectedKey, selectedDate);
                    BackupManager backupManager = new BackupManager(backupFolderTextBox.Text, s3Service, intervalMilliseconds, false);
                    string formFieldsData = $"{serverTextBox.Text},{accessKeyTextBox.Text},{secretKeyTextBox.Text},{bucketNameTextBox.Text},{backupFolderTextBox.Text},{Convert.ToString(selectedKey)}, {Convert.ToString(selectedDate)}";
                    Storage.SaveFormFields(formFieldsData);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Date must be future!");
                }
            }
            else
            {
                MessageBox.Show("All fields are required!");
            }
        }

        public double GetIntervalFromNextOccurrence(int periodKey, DateTime selectedDate)
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
    }
}