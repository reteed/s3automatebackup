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
        private SecureFormStorage storage = new();

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
            string loadedData = storage.LoadFormFields();
            if (loadedData != null)
            {
                string[] fieldValues = loadedData.Split(',');
                serverTextBox.Text = fieldValues[0];
                accessKeyTextBox.Text = fieldValues[1];
                secretKeyTextBox.Text = fieldValues[2];
                bucketNameTextBox.Text = fieldValues[3];
                backupFolderTextBox.Text = fieldValues[4];
                periodComboBox.SelectedIndex = Convert.ToInt32(fieldValues[5]) - 1;
            }
        }

        private void generateTaskButton_Click(object sender, EventArgs e)
        {
            S3Uploader uploader = new S3Uploader(serverTextBox.Text, accessKeyTextBox.Text, secretKeyTextBox.Text, bucketNameTextBox.Text);
            int selectedKey = ((KeyValuePair<int, string>)periodComboBox.SelectedItem).Key;
            double intervalMilliseconds = GetIntervalFromPeriod(selectedKey);
            BackupManager backupManager = new BackupManager(backupFolderTextBox.Text, uploader, intervalMilliseconds);
            string formFieldsData = $"{serverTextBox.Text},{accessKeyTextBox.Text},{secretKeyTextBox.Text},{bucketNameTextBox.Text},{backupFolderTextBox.Text},{Convert.ToString(selectedKey)}";
            storage.SaveFormFields(formFieldsData);
            this.Hide();
        }

        public double GetIntervalFromPeriod(int periodKey)
        {
            switch (periodKey)
            {
                case 1: // Daily
                    return TimeSpan.FromDays(1).TotalMilliseconds;
                case 2: // Weekly
                    return TimeSpan.FromDays(7).TotalMilliseconds;
                case 3: // Monthly (assuming 30 days for simplicity)
                    return TimeSpan.FromDays(30).TotalMilliseconds;
                default:
                    throw new ArgumentException("Invalid period key");
            }
        }

        private void ScheduleBackup()
        {
            S3Uploader uploader = new S3Uploader(serverTextBox.Text, accessKeyTextBox.Text, secretKeyTextBox.Text, bucketNameTextBox.Text);
            int selectedKey = ((KeyValuePair<int, string>)periodComboBox.SelectedItem).Key;
            double intervalMilliseconds = GetIntervalFromPeriod(selectedKey);
            BackupManager backupManager = new BackupManager(backupFolderTextBox.Text, uploader, intervalMilliseconds);
        }
    }
}