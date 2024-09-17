using s3automatebackup.Models;
using s3automatebackup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s3automatebackup.Forms
{
    public partial class CreateTaskForm : Form
    {
        public BackupTask Task { get; private set; }
        private List<Configuration> Configurations = new();
        private StorageService storageService = new();
        bool ByPassDateCheck = false;

        public CreateTaskForm()
        {
            InitializeComponent();
            Configurations = storageService.LoadConfigurations();
            PopulateConfigurations();
            PopulatePeriodComboBox();
        }

        public CreateTaskForm(BackupTask task)
        {
            InitializeComponent();
            Configurations = storageService.LoadConfigurations();
            PopulateConfigurations();
            Task = task;

            // Populate form fields with task data
            if (Task != null)
            {
                ByPassDateCheck = true;
                backupFolderTextBox.Text = Task.BackupPath;
                scheduledDateAndTimeDateTimePicker.Value = Task.ScheduledTime;

                // Set the selected configuration
                if (Task.Configuration != null)
                {
                    int configId = Task.Configuration.Id;
                    configurationComboBox.SelectedValue = configId;

                    // Populate buckets based on the configuration
                    PopulateBuckets(Task.Configuration);
                }

                PopulatePeriodComboBox();
                deletePathCheckBox.Checked = task.DeletePath;
                hierarchyCheckBox.Checked = task.Hierarchy;
                removeOldFilesCheckbox.Checked = task.RemoveOldFiles;
                daysInputTextBox.Text = task.OldFilesDays.ToString();
            }
        }

        private void PopulateConfigurations()
        {
            List<Configuration> configurations = storageService.LoadConfigurations();
            Dictionary<int, string> configurationDictionary = new();
            foreach (Configuration configuration in configurations)
            {
                configurationDictionary.Add(configuration.Id, configuration.Name);
            }

            configurationComboBox.DataSource = new BindingSource(configurationDictionary, null);
            configurationComboBox.DisplayMember = "Value"; // Display the configuration name
            configurationComboBox.ValueMember = "Key"; // Use the configuration ID as the underlying value

            configurationComboBox.SelectedIndex = -1;
        }

        private async void PopulateBuckets(Configuration config)
        {
            S3Service s3Service = new S3Service(config.Server, config.AccessKey, config.SecretKey, null);
            List<string> buckets = await s3Service.ListAllBucketsAsync();

            bucketComboBox.DataSource = buckets;
            bucketComboBox.SelectedIndex = -1;
            // Set the selected bucket name
            if (Task != null)
            {
                if (!string.IsNullOrWhiteSpace(Task.BucketName))
                {
                    bucketComboBox.SelectedItem = Task.BucketName;
                }
            }
        }


        private void PopulatePeriodComboBox()
        {
            Dictionary<int, string> periodOptions = new Dictionary<int, string>
            {
                { 1, "Daily" },
                { 2, "Weekly" },
                { 3, "Monthly" },
                { 4, "Yearly" }
            };

            periodComboBox.DataSource = new BindingSource(periodOptions, null);
            periodComboBox.DisplayMember = "Value";
            periodComboBox.ValueMember = "Key";

            // If editing an existing task, select the current value
            if (Task != null)
            {
                periodComboBox.SelectedValue = Task.PeriodKey;
            }
            else
            {
                periodComboBox.SelectedIndex = -1;
            }
        }

        private void configurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configurationComboBox.SelectedIndex != -1)
            {
                var selectedConfig = ((KeyValuePair<int, string>)configurationComboBox.SelectedItem).Key;
                Configuration config = Configurations.FirstOrDefault(c => c.Id == selectedConfig);
                if (config != null)
                {
                    PopulateBuckets(config);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = scheduledDateAndTimeDateTimePicker.Value;
            DateTime dateNow = DateTime.Now;

            if (bucketComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a bucket.", "Missing Bucket", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(backupFolderTextBox.Text) && date > dateNow && configurationComboBox.SelectedIndex > -1)
            {
                if (Task == null)
                {
                    Task = new BackupTask();
                }

                Task.BucketName = bucketComboBox.SelectedItem.ToString();
                Task.BackupPath = backupFolderTextBox.Text;
                Task.ScheduledTime = scheduledDateAndTimeDateTimePicker.Value;
                Task.PeriodKey = (int)periodComboBox.SelectedValue;
                Task.DeletePath = deletePathCheckBox.Checked;
                Task.Hierarchy = hierarchyCheckBox.Checked;

                if (removeOldFilesCheckbox.Checked && int.TryParse(daysInputTextBox.Text, out int days))
                {
                    if (days > 0)
                    {
                        Task.RemoveOldFiles = true;
                        Task.OldFilesDays = days;
                    }
                    else
                    {
                        Task.RemoveOldFiles = false;
                    }
                }
                else
                {
                    Task.RemoveOldFiles = false;
                }

                // Fix the retrieval of the selected configuration ID
                int selectedConfigId = ((KeyValuePair<int, string>)configurationComboBox.SelectedItem).Key;
                Configuration selectedConfig = Configurations.FirstOrDefault(c => c.Id == selectedConfigId);
                Task.Configuration = selectedConfig;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (date <= dateNow)
                {
                    MessageBox.Show("Please select a date and time in the future.", "Invalid Date Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please fill in all the required fields before proceeding.", "Required Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void scheduledDateAndTimeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Get the selected date and time from the DateTimePicker
            DateTime selectedDate = scheduledDateAndTimeDateTimePicker.Value;

            // Check if the selected date is in the past
            if (selectedDate <= DateTime.Now && !ByPassDateCheck)
            {
                MessageBox.Show("Please select a date and time in the future.", "Invalid Date Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DateTime dateNow = DateTime.Now;
                scheduledDateAndTimeDateTimePicker.Value = dateNow.AddHours(1);
            }
            else
            {
                ByPassDateCheck = false;
            }
        }

        private void ClearFields()
        {
            backupFolderTextBox.Text = string.Empty;
            configurationComboBox.SelectedIndex = -1;
            bucketComboBox.SelectedIndex = -1;
            periodComboBox.SelectedIndex = -1;
            deletePathCheckBox.Checked = false;
            hierarchyCheckBox.Checked = false;
            removeOldFilesCheckbox.Checked = false;
            daysInputTextBox.Text = string.Empty;
        }

        private void CreateTaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearFields();
        }

        private void browsePathButton_Click(object sender, EventArgs e)
        {
            // Ask the user if they want to select a folder or a file
            var result = MessageBox.Show("Do you want to select a folder? Click 'No' to select a file.", "Select Path Type", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Folder selection
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select the backup folder";

                    // Show the folder browser dialog
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        backupFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                // File selection
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select the backup file";
                    openFileDialog.Filter = "All files (*.*)|*.*";  // Allow all file types

                    // Show the file open dialog
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        backupFolderTextBox.Text = openFileDialog.FileName;
                    }
                }
            }
            // If the user clicks Cancel, do nothing
        }
    }
}