namespace s3automatebackup.Forms
{
    partial class CreateConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateConfigurationForm));
            saveButton = new Button();
            cancelButton = new Button();
            nameLabel = new Label();
            serverLabel = new Label();
            accessKeyLabel = new Label();
            secretKeyLabel = new Label();
            nameTextBox = new TextBox();
            serverTextBox = new TextBox();
            accessKeyTextBox = new TextBox();
            secretKeyTextBox = new TextBox();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(357, 200);
            saveButton.Margin = new Padding(2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(80, 30);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(126, 200);
            cancelButton.Margin = new Padding(2);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(80, 30);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            nameLabel.Location = new Point(36, 42);
            nameLabel.Margin = new Padding(2, 0, 2, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(43, 15);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name:";
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            serverLabel.Location = new Point(202, 42);
            serverLabel.Margin = new Padding(2, 0, 2, 0);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(89, 15);
            serverLabel.TabIndex = 3;
            serverLabel.Text = "Server or URL:";
            // 
            // accessKeyLabel
            // 
            accessKeyLabel.AutoSize = true;
            accessKeyLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            accessKeyLabel.Location = new Point(104, 92);
            accessKeyLabel.Margin = new Padding(2, 0, 2, 0);
            accessKeyLabel.Name = "accessKeyLabel";
            accessKeyLabel.Size = new Size(71, 15);
            accessKeyLabel.TabIndex = 4;
            accessKeyLabel.Text = "Access Key:";
            // 
            // secretKeyLabel
            // 
            secretKeyLabel.AutoSize = true;
            secretKeyLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            secretKeyLabel.Location = new Point(104, 127);
            secretKeyLabel.Margin = new Padding(2, 0, 2, 0);
            secretKeyLabel.Name = "secretKeyLabel";
            secretKeyLabel.Size = new Size(71, 15);
            secretKeyLabel.TabIndex = 5;
            secretKeyLabel.Text = "Secret Key:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(83, 42);
            nameTextBox.Margin = new Padding(2);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(106, 23);
            nameTextBox.TabIndex = 6;
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(295, 42);
            serverTextBox.Margin = new Padding(2);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(227, 23);
            serverTextBox.TabIndex = 7;
            // 
            // accessKeyTextBox
            // 
            accessKeyTextBox.Location = new Point(180, 92);
            accessKeyTextBox.Margin = new Padding(2);
            accessKeyTextBox.Name = "accessKeyTextBox";
            accessKeyTextBox.Size = new Size(271, 23);
            accessKeyTextBox.TabIndex = 8;
            // 
            // secretKeyTextBox
            // 
            secretKeyTextBox.Location = new Point(180, 127);
            secretKeyTextBox.Margin = new Padding(2);
            secretKeyTextBox.Name = "secretKeyTextBox";
            secretKeyTextBox.Size = new Size(271, 23);
            secretKeyTextBox.TabIndex = 9;
            // 
            // CreateConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(secretKeyTextBox);
            Controls.Add(accessKeyTextBox);
            Controls.Add(serverTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(secretKeyLabel);
            Controls.Add(accessKeyLabel);
            Controls.Add(serverLabel);
            Controls.Add(nameLabel);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "CreateConfigurationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Configuration - S3AutomateBackup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private Button cancelButton;
        private Label nameLabel;
        private Label serverLabel;
        private Label accessKeyLabel;
        private Label secretKeyLabel;
        private TextBox nameTextBox;
        private TextBox serverTextBox;
        private TextBox accessKeyTextBox;
        private TextBox secretKeyTextBox;
    }
}