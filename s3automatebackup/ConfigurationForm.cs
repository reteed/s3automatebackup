using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace S3AutomateBackup
{
    public partial class ConfigurationForm : Form
    {
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

        }

        private void generateTaskButton_Click(object sender, EventArgs e)
        {
            S3Uploader uploader = new S3Uploader(serverTextBox.Text, accessKeyTextBox.Text, secretKeyTextBox.Text, bucketNameTextBox.Text);
            int selectedKey = ((KeyValuePair<int, string>)periodComboBox.SelectedItem).Key;
            string selectedValue = ((KeyValuePair<int, string>)periodComboBox.SelectedItem).Value;
            double intervalMilliseconds = GetIntervalFromPeriod(selectedKey);
            BackupManager backupManager = new BackupManager(backupFolderTextBox.Text, uploader, intervalMilliseconds);
            // Minimize the app.
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
    }
}