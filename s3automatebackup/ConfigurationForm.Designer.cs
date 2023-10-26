namespace S3AutomateBackup
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            serverTextBox = new TextBox();
            s3ConfigurationLabel = new Label();
            serverLabel = new Label();
            accessKeyLabel = new Label();
            secretKeyLabel = new Label();
            accessKeyTextBox = new TextBox();
            secretKeyTextBox = new TextBox();
            backupFolderLabel = new Label();
            backupFolderTextBox = new TextBox();
            periodComboBox = new ComboBox();
            periodLabel = new Label();
            generateTaskButton = new Button();
            bucketNameLabel = new Label();
            bucketNameTextBox = new TextBox();
            dayDateTimePicker = new DateTimePicker();
            dayLabel = new Label();
            firstBackupCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(190, 153);
            serverTextBox.Margin = new Padding(4, 5, 4, 5);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(311, 31);
            serverTextBox.TabIndex = 0;
            // 
            // s3ConfigurationLabel
            // 
            s3ConfigurationLabel.AutoSize = true;
            s3ConfigurationLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            s3ConfigurationLabel.Location = new Point(34, 37);
            s3ConfigurationLabel.Margin = new Padding(4, 0, 4, 0);
            s3ConfigurationLabel.Name = "s3ConfigurationLabel";
            s3ConfigurationLabel.Size = new Size(274, 45);
            s3ConfigurationLabel.TabIndex = 1;
            s3ConfigurationLabel.Text = "S3 Configuration";
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            serverLabel.Location = new Point(43, 153);
            serverLabel.Margin = new Padding(4, 0, 4, 0);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(146, 32);
            serverLabel.TabIndex = 2;
            serverLabel.Text = "Server URL:";
            // 
            // accessKeyLabel
            // 
            accessKeyLabel.AutoSize = true;
            accessKeyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            accessKeyLabel.Location = new Point(43, 242);
            accessKeyLabel.Margin = new Padding(4, 0, 4, 0);
            accessKeyLabel.Name = "accessKeyLabel";
            accessKeyLabel.Size = new Size(146, 32);
            accessKeyLabel.TabIndex = 3;
            accessKeyLabel.Text = "Access Key:";
            // 
            // secretKeyLabel
            // 
            secretKeyLabel.AutoSize = true;
            secretKeyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            secretKeyLabel.Location = new Point(43, 342);
            secretKeyLabel.Margin = new Padding(4, 0, 4, 0);
            secretKeyLabel.Name = "secretKeyLabel";
            secretKeyLabel.Size = new Size(140, 32);
            secretKeyLabel.TabIndex = 4;
            secretKeyLabel.Text = "Secret Key:";
            // 
            // accessKeyTextBox
            // 
            accessKeyTextBox.Location = new Point(189, 245);
            accessKeyTextBox.Margin = new Padding(4, 5, 4, 5);
            accessKeyTextBox.Name = "accessKeyTextBox";
            accessKeyTextBox.Size = new Size(348, 31);
            accessKeyTextBox.TabIndex = 5;
            // 
            // secretKeyTextBox
            // 
            secretKeyTextBox.Location = new Point(184, 342);
            secretKeyTextBox.Margin = new Padding(4, 5, 4, 5);
            secretKeyTextBox.Name = "secretKeyTextBox";
            secretKeyTextBox.Size = new Size(351, 31);
            secretKeyTextBox.TabIndex = 6;
            // 
            // backupFolderLabel
            // 
            backupFolderLabel.AutoSize = true;
            backupFolderLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            backupFolderLabel.Location = new Point(596, 148);
            backupFolderLabel.Margin = new Padding(4, 0, 4, 0);
            backupFolderLabel.Name = "backupFolderLabel";
            backupFolderLabel.Size = new Size(184, 32);
            backupFolderLabel.TabIndex = 7;
            backupFolderLabel.Text = "Backup Folder:";
            // 
            // backupFolderTextBox
            // 
            backupFolderTextBox.Location = new Point(780, 148);
            backupFolderTextBox.Margin = new Padding(4, 5, 4, 5);
            backupFolderTextBox.Name = "backupFolderTextBox";
            backupFolderTextBox.Size = new Size(308, 31);
            backupFolderTextBox.TabIndex = 8;
            // 
            // periodComboBox
            // 
            periodComboBox.FormattingEnabled = true;
            periodComboBox.Location = new Point(696, 245);
            periodComboBox.Margin = new Padding(4, 5, 4, 5);
            periodComboBox.Name = "periodComboBox";
            periodComboBox.Size = new Size(171, 33);
            periodComboBox.TabIndex = 9;
            // 
            // periodLabel
            // 
            periodLabel.AutoSize = true;
            periodLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            periodLabel.Location = new Point(596, 248);
            periodLabel.Margin = new Padding(4, 0, 4, 0);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new Size(95, 32);
            periodLabel.TabIndex = 10;
            periodLabel.Text = "Period:";
            // 
            // generateTaskButton
            // 
            generateTaskButton.BackColor = SystemColors.GradientActiveCaption;
            generateTaskButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            generateTaskButton.Location = new Point(426, 595);
            generateTaskButton.Margin = new Padding(4, 5, 4, 5);
            generateTaskButton.Name = "generateTaskButton";
            generateTaskButton.Size = new Size(276, 62);
            generateTaskButton.TabIndex = 11;
            generateTaskButton.Text = "Generate Task";
            generateTaskButton.UseVisualStyleBackColor = false;
            generateTaskButton.Click += generateTaskButton_Click;
            // 
            // bucketNameLabel
            // 
            bucketNameLabel.AutoSize = true;
            bucketNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bucketNameLabel.Location = new Point(43, 442);
            bucketNameLabel.Margin = new Padding(4, 0, 4, 0);
            bucketNameLabel.Name = "bucketNameLabel";
            bucketNameLabel.Size = new Size(172, 32);
            bucketNameLabel.TabIndex = 12;
            bucketNameLabel.Text = "Bucket Name:";
            // 
            // bucketNameTextBox
            // 
            bucketNameTextBox.Location = new Point(216, 447);
            bucketNameTextBox.Margin = new Padding(4, 5, 4, 5);
            bucketNameTextBox.Name = "bucketNameTextBox";
            bucketNameTextBox.Size = new Size(320, 31);
            bucketNameTextBox.TabIndex = 13;
            // 
            // dayDateTimePicker
            // 
            dayDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dayDateTimePicker.Format = DateTimePickerFormat.Custom;
            dayDateTimePicker.Location = new Point(696, 350);
            dayDateTimePicker.Margin = new Padding(4, 5, 4, 5);
            dayDateTimePicker.Name = "dayDateTimePicker";
            dayDateTimePicker.Size = new Size(392, 31);
            dayDateTimePicker.TabIndex = 14;
            // 
            // dayLabel
            // 
            dayLabel.AutoSize = true;
            dayLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dayLabel.Location = new Point(596, 350);
            dayLabel.Margin = new Padding(4, 0, 4, 0);
            dayLabel.Name = "dayLabel";
            dayLabel.Size = new Size(65, 32);
            dayLabel.TabIndex = 15;
            dayLabel.Text = "Day:";
            // 
            // firstBackupCheckBox
            // 
            firstBackupCheckBox.AutoSize = true;
            firstBackupCheckBox.Checked = true;
            firstBackupCheckBox.CheckState = CheckState.Checked;
            firstBackupCheckBox.Location = new Point(596, 449);
            firstBackupCheckBox.Name = "firstBackupCheckBox";
            firstBackupCheckBox.Size = new Size(173, 29);
            firstBackupCheckBox.TabIndex = 16;
            firstBackupCheckBox.Text = "First backup now";
            firstBackupCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(firstBackupCheckBox);
            Controls.Add(dayLabel);
            Controls.Add(dayDateTimePicker);
            Controls.Add(bucketNameTextBox);
            Controls.Add(bucketNameLabel);
            Controls.Add(generateTaskButton);
            Controls.Add(periodLabel);
            Controls.Add(periodComboBox);
            Controls.Add(backupFolderTextBox);
            Controls.Add(backupFolderLabel);
            Controls.Add(secretKeyTextBox);
            Controls.Add(accessKeyTextBox);
            Controls.Add(secretKeyLabel);
            Controls.Add(accessKeyLabel);
            Controls.Add(serverLabel);
            Controls.Add(s3ConfigurationLabel);
            Controls.Add(serverTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "ConfigurationForm";
            Text = "Configuration - S3AutomateBackup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox serverTextBox;
        private Label s3ConfigurationLabel;
        private Label serverLabel;
        private Label accessKeyLabel;
        private Label secretKeyLabel;
        private TextBox accessKeyTextBox;
        private TextBox secretKeyTextBox;
        private Label backupFolderLabel;
        private TextBox backupFolderTextBox;
        private ComboBox periodComboBox;
        private Label periodLabel;
        private Button generateTaskButton;
        private Label bucketNameLabel;
        private TextBox bucketNameTextBox;
        private DateTimePicker dayDateTimePicker;
        private Label dayLabel;
        private CheckBox firstBackupCheckBox;
    }
}