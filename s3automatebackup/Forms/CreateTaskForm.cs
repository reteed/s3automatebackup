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
                bucketNameTextBox.Text = Task.BucketName;
                backupFolderTextBox.Text = Task.BackupPath;
                scheduledDateAndTimeDateTimePicker.Value = Task.ScheduledTime;
                // Set the selected value of the configurationComboBox
                if (Task.Configuration != null)
                {
                    int configId = Task.Configuration.Id;
                    configurationComboBox.SelectedValue = configId;
                }
                PopulatePeriodComboBox();
                deletePathCheckBox.Checked = task.DeletePath;
                hierarchyCheckBox.Checked = task.Hierarchy;
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


        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = scheduledDateAndTimeDateTimePicker.Value;
            DateTime dateNow = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(bucketNameTextBox.Text) && !string.IsNullOrWhiteSpace(backupFolderTextBox.Text) && date > dateNow && configurationComboBox.SelectedIndex > -1)
            {
                if (Task == null)
                {
                    Task = new BackupTask();
                }

                Task.BucketName = bucketNameTextBox.Text;
                Task.BackupPath = backupFolderTextBox.Text;
                Task.ScheduledTime = scheduledDateAndTimeDateTimePicker.Value;
                Task.PeriodKey = (int)periodComboBox.SelectedValue;
                Task.DeletePath = deletePathCheckBox.Checked;
                Task.Hierarchy = hierarchyCheckBox.Checked;

                // Get the selected configuration ID and find the corresponding Configuration object
                int selectedConfigId = (int)configurationComboBox.SelectedValue;
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
    }
}