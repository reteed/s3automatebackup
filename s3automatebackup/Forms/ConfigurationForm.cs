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

namespace s3automatebackup.Forms
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

        private double GetIntervalFromNextOccurrence(int periodKey, DateTime selectedDate)
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
    }
}