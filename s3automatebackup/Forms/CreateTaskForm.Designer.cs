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
            bucketNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bucketNameLabel.AutoSize = true;
            bucketNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bucketNameLabel.Location = new Point(332, 36);
            bucketNameLabel.Margin = new Padding(2, 0, 2, 0);
            bucketNameLabel.Name = "bucketNameLabel";
            bucketNameLabel.Size = new Size(84, 15);
            bucketNameLabel.TabIndex = 0;
            bucketNameLabel.Text = "Bucket name:";
            // 
            // backupPathLabel
            // 
            backupPathLabel.AutoSize = true;
            backupPathLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            backupPathLabel.Location = new Point(68, 82);
            backupPathLabel.Margin = new Padding(2, 0, 2, 0);
            backupPathLabel.Name = "backupPathLabel";
            backupPathLabel.Size = new Size(139, 15);
            backupPathLabel.TabIndex = 1;
            backupPathLabel.Text = "Backup folder/file path:";
            // 
            // scheduledTimeLabel
            // 
            scheduledTimeLabel.AutoSize = true;
            scheduledTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            scheduledTimeLabel.Location = new Point(68, 133);
            scheduledTimeLabel.Margin = new Padding(2, 0, 2, 0);
            scheduledTimeLabel.Name = "scheduledTimeLabel";
            scheduledTimeLabel.Size = new Size(142, 15);
            scheduledTimeLabel.TabIndex = 2;
            scheduledTimeLabel.Text = "Sheduled date and time:";
            // 
            // periodLabel
            // 
            periodLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            periodLabel.AutoSize = true;
            periodLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            periodLabel.Location = new Point(420, 133);
            periodLabel.Margin = new Padding(2, 0, 2, 0);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new Size(46, 15);
            periodLabel.TabIndex = 3;
            periodLabel.Text = "Period:";
            // 
            // backupFolderTextBox
            // 
            backupFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            backupFolderTextBox.Location = new Point(217, 79);
            backupFolderTextBox.Margin = new Padding(2);
            backupFolderTextBox.Name = "backupFolderTextBox";
            backupFolderTextBox.Size = new Size(229, 23);
            backupFolderTextBox.TabIndex = 5;
            // 
            // scheduledDateAndTimeDateTimePicker
            // 
            scheduledDateAndTimeDateTimePicker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            scheduledDateAndTimeDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            scheduledDateAndTimeDateTimePicker.Format = DateTimePickerFormat.Custom;
            scheduledDateAndTimeDateTimePicker.Location = new Point(217, 133);
            scheduledDateAndTimeDateTimePicker.Margin = new Padding(2);
            scheduledDateAndTimeDateTimePicker.Name = "scheduledDateAndTimeDateTimePicker";
            scheduledDateAndTimeDateTimePicker.Size = new Size(180, 23);
            scheduledDateAndTimeDateTimePicker.TabIndex = 6;
            scheduledDateAndTimeDateTimePicker.ValueChanged += scheduledDateAndTimeDateTimePicker_ValueChanged;
            // 
            // periodComboBox
            // 
            periodComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            periodComboBox.FormattingEnabled = true;
            periodComboBox.Location = new Point(470, 133);
            periodComboBox.Margin = new Padding(2);
            periodComboBox.Name = "periodComboBox";
            periodComboBox.Size = new Size(129, 23);
            periodComboBox.TabIndex = 7;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(181, 363);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(80, 30);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Location = new Point(420, 363);
            saveButton.Margin = new Padding(2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(80, 30);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // configurationLabel
            // 
            configurationLabel.AutoSize = true;
            configurationLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            configurationLabel.Location = new Point(71, 36);
            configurationLabel.Margin = new Padding(2, 0, 2, 0);
            configurationLabel.Name = "configurationLabel";
            configurationLabel.Size = new Size(86, 15);
            configurationLabel.TabIndex = 10;
            configurationLabel.Text = "Configuration:";
            // 
            // configurationComboBox
            // 
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Location = new Point(161, 36);
            configurationComboBox.Margin = new Padding(2);
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.Size = new Size(129, 23);
            configurationComboBox.TabIndex = 11;
            configurationComboBox.SelectedIndexChanged += configurationComboBox_SelectedIndexChanged;
            // 
            // deletePathCheckBox
            // 
            deletePathCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            deletePathCheckBox.AutoSize = true;
            deletePathCheckBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deletePathCheckBox.Location = new Point(98, 215);
            deletePathCheckBox.Margin = new Padding(2);
            deletePathCheckBox.Name = "deletePathCheckBox";
            deletePathCheckBox.Size = new Size(230, 19);
            deletePathCheckBox.TabIndex = 13;
            deletePathCheckBox.Text = "Delete backed up file/s from local disk.";
            deletePathCheckBox.UseVisualStyleBackColor = true;
            // 
            // hierarchyCheckBox
            // 
            hierarchyCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            hierarchyCheckBox.AutoSize = true;
            hierarchyCheckBox.Location = new Point(98, 238);
            hierarchyCheckBox.Margin = new Padding(2);
            hierarchyCheckBox.Name = "hierarchyCheckBox";
            hierarchyCheckBox.Size = new Size(249, 19);
            hierarchyCheckBox.TabIndex = 14;
            hierarchyCheckBox.Text = "Back up file/s keeping directory hierarchy?";
            hierarchyCheckBox.UseVisualStyleBackColor = true;
            // 
            // additionalSettingsLabel
            // 
            additionalSettingsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            additionalSettingsLabel.AutoSize = true;
            additionalSettingsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            additionalSettingsLabel.Location = new Point(68, 188);
            additionalSettingsLabel.Name = "additionalSettingsLabel";
            additionalSettingsLabel.Size = new Size(113, 15);
            additionalSettingsLabel.TabIndex = 15;
            additionalSettingsLabel.Text = "Additional settings:";
            // 
            // removeOldFilesCheckbox
            // 
            removeOldFilesCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            removeOldFilesCheckbox.AutoSize = true;
            removeOldFilesCheckbox.Location = new Point(97, 269);
            removeOldFilesCheckbox.Name = "removeOldFilesCheckbox";
            removeOldFilesCheckbox.Size = new Size(150, 19);
            removeOldFilesCheckbox.TabIndex = 16;
            removeOldFilesCheckbox.Text = "Remove files older than";
            removeOldFilesCheckbox.UseVisualStyleBackColor = true;
            // 
            // daysInputTextBox
            // 
            daysInputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            daysInputTextBox.Location = new Point(253, 267);
            daysInputTextBox.Name = "daysInputTextBox";
            daysInputTextBox.Size = new Size(67, 23);
            daysInputTextBox.TabIndex = 17;
            // 
            // labelOldFiles
            // 
            labelOldFiles.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelOldFiles.AutoSize = true;
            labelOldFiles.Location = new Point(332, 273);
            labelOldFiles.Name = "labelOldFiles";
            labelOldFiles.Size = new Size(34, 15);
            labelOldFiles.TabIndex = 18;
            labelOldFiles.Text = "days.";
            // 
            // bucketComboBox
            // 
            bucketComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bucketComboBox.FormattingEnabled = true;
            bucketComboBox.Location = new Point(421, 36);
            bucketComboBox.Name = "bucketComboBox";
            bucketComboBox.Size = new Size(132, 23);
            bucketComboBox.TabIndex = 19;
            // 
            // browsePathButton
            // 
            browsePathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browsePathButton.Location = new Point(451, 79);
            browsePathButton.Name = "browsePathButton";
            browsePathButton.Size = new Size(75, 23);
            browsePathButton.TabIndex = 20;
            browsePathButton.Text = "Browse";
            browsePathButton.UseVisualStyleBackColor = true;
            browsePathButton.Click += browsePathButton_Click;
            // 
            // encryptBackupCheckbox
            // 
            encryptBackupCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            encryptBackupCheckbox.AutoSize = true;
            encryptBackupCheckbox.Location = new Point(98, 304);
            encryptBackupCheckbox.Name = "encryptBackupCheckbox";
            encryptBackupCheckbox.Size = new Size(111, 19);
            encryptBackupCheckbox.TabIndex = 21;
            encryptBackupCheckbox.Text = "Encrypt Backup.";
            encryptBackupCheckbox.UseVisualStyleBackColor = true;
            encryptBackupCheckbox.CheckedChanged += encryptBackupCheckbox_CheckedChanged;
            // 
            // CreateTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 437);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "CreateTaskForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Task - S3AutomateBackup";
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