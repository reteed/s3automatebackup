namespace s3automatebackup.Forms
{
    partial class CreateTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTaskForm));
            bucketNameLabel = new Label();
            backupPathLabel = new Label();
            scheduledTimeLabel = new Label();
            periodLabel = new Label();
            backupFolderTextBox = new TextBox();
            scheduledDateAndTimeDateTimePicker = new DateTimePicker();
            periodComboBox = new ComboBox();
            cancelButton = new Button();
            saveButton = new Button();
            configurationLabel = new Label();
            configurationComboBox = new ComboBox();
            deletePathCheckBox = new CheckBox();
            hierarchyCheckBox = new CheckBox();
            additionalSettingsLabel = new Label();
            removeOldFilesCheckbox = new CheckBox();
            daysInputTextBox = new TextBox();
            labelOldFiles = new Label();
            bucketComboBox = new ComboBox();
            browsePathButton = new Button();
            encryptBackupCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // bucketNameLabel
            // 
            resources.ApplyResources(bucketNameLabel, "bucketNameLabel");
            bucketNameLabel.Name = "bucketNameLabel";
            // 
            // backupPathLabel
            // 
            resources.ApplyResources(backupPathLabel, "backupPathLabel");
            backupPathLabel.Name = "backupPathLabel";
            // 
            // scheduledTimeLabel
            // 
            resources.ApplyResources(scheduledTimeLabel, "scheduledTimeLabel");
            scheduledTimeLabel.Name = "scheduledTimeLabel";
            // 
            // periodLabel
            // 
            resources.ApplyResources(periodLabel, "periodLabel");
            periodLabel.Name = "periodLabel";
            // 
            // backupFolderTextBox
            // 
            resources.ApplyResources(backupFolderTextBox, "backupFolderTextBox");
            backupFolderTextBox.Name = "backupFolderTextBox";
            // 
            // scheduledDateAndTimeDateTimePicker
            // 
            resources.ApplyResources(scheduledDateAndTimeDateTimePicker, "scheduledDateAndTimeDateTimePicker");
            scheduledDateAndTimeDateTimePicker.Format = DateTimePickerFormat.Custom;
            scheduledDateAndTimeDateTimePicker.Name = "scheduledDateAndTimeDateTimePicker";
            scheduledDateAndTimeDateTimePicker.ValueChanged += scheduledDateAndTimeDateTimePicker_ValueChanged;
            // 
            // periodComboBox
            // 
            resources.ApplyResources(periodComboBox, "periodComboBox");
            periodComboBox.FormattingEnabled = true;
            periodComboBox.Name = "periodComboBox";
            // 
            // cancelButton
            // 
            resources.ApplyResources(cancelButton, "cancelButton");
            cancelButton.Name = "cancelButton";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.Name = "saveButton";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // configurationLabel
            // 
            resources.ApplyResources(configurationLabel, "configurationLabel");
            configurationLabel.Name = "configurationLabel";
            // 
            // configurationComboBox
            // 
            resources.ApplyResources(configurationComboBox, "configurationComboBox");
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.SelectedIndexChanged += configurationComboBox_SelectedIndexChanged;
            // 
            // deletePathCheckBox
            // 
            resources.ApplyResources(deletePathCheckBox, "deletePathCheckBox");
            deletePathCheckBox.Name = "deletePathCheckBox";
            deletePathCheckBox.UseVisualStyleBackColor = true;
            // 
            // hierarchyCheckBox
            // 
            resources.ApplyResources(hierarchyCheckBox, "hierarchyCheckBox");
            hierarchyCheckBox.Name = "hierarchyCheckBox";
            hierarchyCheckBox.UseVisualStyleBackColor = true;
            // 
            // additionalSettingsLabel
            // 
            resources.ApplyResources(additionalSettingsLabel, "additionalSettingsLabel");
            additionalSettingsLabel.Name = "additionalSettingsLabel";
            // 
            // removeOldFilesCheckbox
            // 
            resources.ApplyResources(removeOldFilesCheckbox, "removeOldFilesCheckbox");
            removeOldFilesCheckbox.Name = "removeOldFilesCheckbox";
            removeOldFilesCheckbox.UseVisualStyleBackColor = true;
            // 
            // daysInputTextBox
            // 
            resources.ApplyResources(daysInputTextBox, "daysInputTextBox");
            daysInputTextBox.Name = "daysInputTextBox";
            // 
            // labelOldFiles
            // 
            resources.ApplyResources(labelOldFiles, "labelOldFiles");
            labelOldFiles.Name = "labelOldFiles";
            // 
            // bucketComboBox
            // 
            resources.ApplyResources(bucketComboBox, "bucketComboBox");
            bucketComboBox.FormattingEnabled = true;
            bucketComboBox.Name = "bucketComboBox";
            // 
            // browsePathButton
            // 
            resources.ApplyResources(browsePathButton, "browsePathButton");
            browsePathButton.Name = "browsePathButton";
            browsePathButton.UseVisualStyleBackColor = true;
            browsePathButton.Click += browsePathButton_Click;
            // 
            // encryptBackupCheckbox
            // 
            resources.ApplyResources(encryptBackupCheckbox, "encryptBackupCheckbox");
            encryptBackupCheckbox.Name = "encryptBackupCheckbox";
            encryptBackupCheckbox.UseVisualStyleBackColor = true;
            encryptBackupCheckbox.CheckedChanged += encryptBackupCheckbox_CheckedChanged;
            // 
            // CreateTaskForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(encryptBackupCheckbox);
            Controls.Add(browsePathButton);
            Controls.Add(bucketComboBox);
            Controls.Add(labelOldFiles);
            Controls.Add(daysInputTextBox);
            Controls.Add(removeOldFilesCheckbox);
            Controls.Add(additionalSettingsLabel);
            Controls.Add(hierarchyCheckBox);
            Controls.Add(deletePathCheckBox);
            Controls.Add(configurationComboBox);
            Controls.Add(configurationLabel);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            Controls.Add(periodComboBox);
            Controls.Add(scheduledDateAndTimeDateTimePicker);
            Controls.Add(backupFolderTextBox);
            Controls.Add(periodLabel);
            Controls.Add(scheduledTimeLabel);
            Controls.Add(backupPathLabel);
            Controls.Add(bucketNameLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CreateTaskForm";
            FormClosing += CreateTaskForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bucketNameLabel;
        private Label backupPathLabel;
        private Label scheduledTimeLabel;
        private Label periodLabel;
        private TextBox backupFolderTextBox;
        private DateTimePicker scheduledDateAndTimeDateTimePicker;
        private ComboBox periodComboBox;
        private Button cancelButton;
        private Button saveButton;
        private Label configurationLabel;
        private ComboBox configurationComboBox;
        private CheckBox deletePathCheckBox;
        private CheckBox hierarchyCheckBox;
        private Label additionalSettingsLabel;
        private CheckBox removeOldFilesCheckbox;
        private TextBox daysInputTextBox;
        private Label labelOldFiles;
        private ComboBox bucketComboBox;
        private Button browsePathButton;
        private CheckBox encryptBackupCheckbox;
    }
}