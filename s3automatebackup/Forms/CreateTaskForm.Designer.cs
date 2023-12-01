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
            backupFolderLabel = new Label();
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
            SuspendLayout();
            // 
            // bucketNameLabel
            // 
            bucketNameLabel.AutoSize = true;
            bucketNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bucketNameLabel.Location = new Point(197, 53);
            bucketNameLabel.Name = "bucketNameLabel";
            bucketNameLabel.Size = new Size(128, 25);
            bucketNameLabel.TabIndex = 0;
            bucketNameLabel.Text = "Bucket name:";
            // 
            // backupFolderLabel
            // 
            backupFolderLabel.AutoSize = true;
            backupFolderLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            backupFolderLabel.Location = new Point(145, 115);
            backupFolderLabel.Name = "backupFolderLabel";
            backupFolderLabel.Size = new Size(180, 25);
            backupFolderLabel.TabIndex = 1;
            backupFolderLabel.Text = "Backup folder path:";
            // 
            // scheduledTimeLabel
            // 
            scheduledTimeLabel.AutoSize = true;
            scheduledTimeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            scheduledTimeLabel.Location = new Point(106, 188);
            scheduledTimeLabel.Name = "scheduledTimeLabel";
            scheduledTimeLabel.Size = new Size(219, 25);
            scheduledTimeLabel.TabIndex = 2;
            scheduledTimeLabel.Text = "Sheduled date and time:";
            // 
            // periodLabel
            // 
            periodLabel.AutoSize = true;
            periodLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            periodLabel.Location = new Point(254, 252);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new Size(71, 25);
            periodLabel.TabIndex = 3;
            periodLabel.Text = "Period:";
            // 
            // bucketNameTextBox
            // 
            bucketNameTextBox.Location = new Point(349, 53);
            bucketNameTextBox.Name = "bucketNameTextBox";
            bucketNameTextBox.Size = new Size(215, 31);
            bucketNameTextBox.TabIndex = 4;
            // 
            // backupFolderTextBox
            // 
            backupFolderTextBox.Location = new Point(349, 115);
            backupFolderTextBox.Name = "backupFolderTextBox";
            backupFolderTextBox.Size = new Size(326, 31);
            backupFolderTextBox.TabIndex = 5;
            // 
            // scheduledDateAndTimeDateTimePicker
            // 
            scheduledDateAndTimeDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            scheduledDateAndTimeDateTimePicker.Format = DateTimePickerFormat.Custom;
            scheduledDateAndTimeDateTimePicker.Location = new Point(346, 185);
            scheduledDateAndTimeDateTimePicker.Name = "scheduledDateAndTimeDateTimePicker";
            scheduledDateAndTimeDateTimePicker.Size = new Size(300, 31);
            scheduledDateAndTimeDateTimePicker.TabIndex = 6;
            scheduledDateAndTimeDateTimePicker.ValueChanged += scheduledDateAndTimeDateTimePicker_ValueChanged;
            // 
            // periodComboBox
            // 
            periodComboBox.FormattingEnabled = true;
            periodComboBox.Location = new Point(346, 252);
            periodComboBox.Name = "periodComboBox";
            periodComboBox.Size = new Size(182, 33);
            periodComboBox.TabIndex = 7;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(175, 371);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(517, 371);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // configurationLabel
            // 
            configurationLabel.AutoSize = true;
            configurationLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            configurationLabel.Location = new Point(192, 305);
            configurationLabel.Name = "configurationLabel";
            configurationLabel.Size = new Size(135, 25);
            configurationLabel.TabIndex = 10;
            configurationLabel.Text = "Configuration:";
            // 
            // configurationComboBox
            // 
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Location = new Point(343, 310);
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.Size = new Size(182, 33);
            configurationComboBox.TabIndex = 11;
            // 
            // CreateTaskForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Controls.Add(backupFolderLabel);
            Controls.Add(bucketNameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateTaskForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Task - S3AutomateBackup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bucketNameLabel;
        private Label backupFolderLabel;
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
    }
}