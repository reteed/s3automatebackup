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
            bucketNameTextBox = new TextBox();
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
            SuspendLayout();
            // 
            // bucketNameLabel
            // 
            bucketNameLabel.AutoSize = true;
            bucketNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            bucketNameLabel.Location = new Point(306, 33);
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
            backupPathLabel.Location = new Point(42, 79);
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
            scheduledTimeLabel.Location = new Point(42, 130);
            scheduledTimeLabel.Margin = new Padding(2, 0, 2, 0);
            scheduledTimeLabel.Name = "scheduledTimeLabel";
            scheduledTimeLabel.Size = new Size(142, 15);
            scheduledTimeLabel.TabIndex = 2;
            scheduledTimeLabel.Text = "Sheduled date and time:";
            // 
            // periodLabel
            // 
            periodLabel.AutoSize = true;
            periodLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            periodLabel.Location = new Point(394, 130);
            periodLabel.Margin = new Padding(2, 0, 2, 0);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new Size(46, 15);
            periodLabel.TabIndex = 3;
            periodLabel.Text = "Period:";
            // 
            // bucketNameTextBox
            // 
            bucketNameTextBox.Location = new Point(394, 33);
            bucketNameTextBox.Margin = new Padding(2);
            bucketNameTextBox.Name = "bucketNameTextBox";
            bucketNameTextBox.Size = new Size(152, 23);
            bucketNameTextBox.TabIndex = 4;
            // 
            // backupFolderTextBox
            // 
            backupFolderTextBox.Location = new Point(191, 76);
            backupFolderTextBox.Margin = new Padding(2);
            backupFolderTextBox.Name = "backupFolderTextBox";
            backupFolderTextBox.Size = new Size(229, 23);
            backupFolderTextBox.TabIndex = 5;
            // 
            // scheduledDateAndTimeDateTimePicker
            // 
            scheduledDateAndTimeDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            scheduledDateAndTimeDateTimePicker.Format = DateTimePickerFormat.Custom;
            scheduledDateAndTimeDateTimePicker.Location = new Point(191, 130);
            scheduledDateAndTimeDateTimePicker.Margin = new Padding(2);
            scheduledDateAndTimeDateTimePicker.Name = "scheduledDateAndTimeDateTimePicker";
            scheduledDateAndTimeDateTimePicker.Size = new Size(180, 23);
            scheduledDateAndTimeDateTimePicker.TabIndex = 6;
            scheduledDateAndTimeDateTimePicker.ValueChanged += scheduledDateAndTimeDateTimePicker_ValueChanged;
            // 
            // periodComboBox
            // 
            periodComboBox.FormattingEnabled = true;
            periodComboBox.Location = new Point(444, 130);
            periodComboBox.Margin = new Padding(2);
            periodComboBox.Name = "periodComboBox";
            periodComboBox.Size = new Size(129, 23);
            periodComboBox.TabIndex = 7;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(154, 311);
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
            saveButton.Location = new Point(393, 311);
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
            configurationLabel.Location = new Point(45, 33);
            configurationLabel.Margin = new Padding(2, 0, 2, 0);
            configurationLabel.Name = "configurationLabel";
            configurationLabel.Size = new Size(86, 15);
            configurationLabel.TabIndex = 10;
            configurationLabel.Text = "Configuration:";
            // 
            // configurationComboBox
            // 
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Location = new Point(135, 33);
            configurationComboBox.Margin = new Padding(2);
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.Size = new Size(129, 23);
            configurationComboBox.TabIndex = 11;
            // 
            // deletePathCheckBox
            // 
            deletePathCheckBox.AutoSize = true;
            deletePathCheckBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deletePathCheckBox.Location = new Point(72, 212);
            deletePathCheckBox.Margin = new Padding(2);
            deletePathCheckBox.Name = "deletePathCheckBox";
            deletePathCheckBox.Size = new Size(230, 19);
            deletePathCheckBox.TabIndex = 13;
            deletePathCheckBox.Text = "Delete backed up file/s from local disk.";
            deletePathCheckBox.UseVisualStyleBackColor = true;
            // 
            // hierarchyCheckBox
            // 
            hierarchyCheckBox.AutoSize = true;
            hierarchyCheckBox.Location = new Point(72, 235);
            hierarchyCheckBox.Margin = new Padding(2);
            hierarchyCheckBox.Name = "hierarchyCheckBox";
            hierarchyCheckBox.Size = new Size(249, 19);
            hierarchyCheckBox.TabIndex = 14;
            hierarchyCheckBox.Text = "Back up file/s keeping directory hierarchy?";
            hierarchyCheckBox.UseVisualStyleBackColor = true;
            // 
            // additionalSettingsLabel
            // 
            additionalSettingsLabel.AutoSize = true;
            additionalSettingsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            additionalSettingsLabel.Location = new Point(42, 185);
            additionalSettingsLabel.Name = "additionalSettingsLabel";
            additionalSettingsLabel.Size = new Size(113, 15);
            additionalSettingsLabel.TabIndex = 15;
            additionalSettingsLabel.Text = "Additional settings:";
            // 
            // CreateTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 382);
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
            Controls.Add(bucketNameTextBox);
            Controls.Add(periodLabel);
            Controls.Add(scheduledTimeLabel);
            Controls.Add(backupPathLabel);
            Controls.Add(bucketNameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "CreateTaskForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Task - S3AutomateBackup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bucketNameLabel;
        private Label backupPathLabel;
        private Label scheduledTimeLabel;
        private Label periodLabel;
        private TextBox bucketNameTextBox;
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
    }
}