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
            SuspendLayout();
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(105, 91);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(219, 23);
            serverTextBox.TabIndex = 0;
            // 
            // s3ConfigurationLabel
            // 
            s3ConfigurationLabel.AutoSize = true;
            s3ConfigurationLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            s3ConfigurationLabel.Location = new Point(24, 22);
            s3ConfigurationLabel.Name = "s3ConfigurationLabel";
            s3ConfigurationLabel.Size = new Size(181, 30);
            s3ConfigurationLabel.TabIndex = 1;
            s3ConfigurationLabel.Text = "S3 Configuration";
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            serverLabel.Location = new Point(30, 92);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(64, 21);
            serverLabel.TabIndex = 2;
            serverLabel.Text = "Server:";
            // 
            // accessKeyLabel
            // 
            accessKeyLabel.AutoSize = true;
            accessKeyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            accessKeyLabel.Location = new Point(30, 145);
            accessKeyLabel.Name = "accessKeyLabel";
            accessKeyLabel.Size = new Size(96, 21);
            accessKeyLabel.TabIndex = 3;
            accessKeyLabel.Text = "Access Key:";
            // 
            // secretKeyLabel
            // 
            secretKeyLabel.AutoSize = true;
            secretKeyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            secretKeyLabel.Location = new Point(30, 205);
            secretKeyLabel.Name = "secretKeyLabel";
            secretKeyLabel.Size = new Size(93, 21);
            secretKeyLabel.TabIndex = 4;
            secretKeyLabel.Text = "Secret Key:";
            // 
            // accessKeyTextBox
            // 
            accessKeyTextBox.Location = new Point(132, 147);
            accessKeyTextBox.Name = "accessKeyTextBox";
            accessKeyTextBox.Size = new Size(245, 23);
            accessKeyTextBox.TabIndex = 5;
            // 
            // secretKeyTextBox
            // 
            secretKeyTextBox.Location = new Point(129, 205);
            secretKeyTextBox.Name = "secretKeyTextBox";
            secretKeyTextBox.Size = new Size(247, 23);
            secretKeyTextBox.TabIndex = 6;
            // 
            // backupFolderLabel
            // 
            backupFolderLabel.AutoSize = true;
            backupFolderLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            backupFolderLabel.Location = new Point(417, 89);
            backupFolderLabel.Name = "backupFolderLabel";
            backupFolderLabel.Size = new Size(123, 21);
            backupFolderLabel.TabIndex = 7;
            backupFolderLabel.Text = "Backup Folder:";
            // 
            // backupFolderTextBox
            // 
            backupFolderTextBox.Location = new Point(546, 89);
            backupFolderTextBox.Name = "backupFolderTextBox";
            backupFolderTextBox.Size = new Size(217, 23);
            backupFolderTextBox.TabIndex = 8;
            // 
            // periodComboBox
            // 
            periodComboBox.FormattingEnabled = true;
            periodComboBox.Location = new Point(487, 147);
            periodComboBox.Name = "periodComboBox";
            periodComboBox.Size = new Size(121, 23);
            periodComboBox.TabIndex = 9;
            // 
            // periodLabel
            // 
            periodLabel.AutoSize = true;
            periodLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            periodLabel.Location = new Point(417, 149);
            periodLabel.Name = "periodLabel";
            periodLabel.Size = new Size(64, 21);
            periodLabel.TabIndex = 10;
            periodLabel.Text = "Period:";
            // 
            // generateTaskButton
            // 
            generateTaskButton.BackColor = SystemColors.GradientActiveCaption;
            generateTaskButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            generateTaskButton.Location = new Point(298, 357);
            generateTaskButton.Name = "generateTaskButton";
            generateTaskButton.Size = new Size(193, 37);
            generateTaskButton.TabIndex = 11;
            generateTaskButton.Text = "Generate Task";
            generateTaskButton.UseVisualStyleBackColor = false;
            generateTaskButton.Click += generateTaskButton_Click;
            // 
            // bucketNameLabel
            // 
            bucketNameLabel.AutoSize = true;
            bucketNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bucketNameLabel.Location = new Point(30, 265);
            bucketNameLabel.Name = "bucketNameLabel";
            bucketNameLabel.Size = new Size(116, 21);
            bucketNameLabel.TabIndex = 12;
            bucketNameLabel.Text = "Bucket Name:";
            // 
            // bucketNameTextBox
            // 
            bucketNameTextBox.Location = new Point(151, 268);
            bucketNameTextBox.Name = "bucketNameTextBox";
            bucketNameTextBox.Size = new Size(225, 23);
            bucketNameTextBox.TabIndex = 13;
            // 
            // ConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}