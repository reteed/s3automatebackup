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
            saveButton.Location = new Point(512, 342);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(181, 342);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            nameLabel.Location = new Point(112, 67);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(67, 25);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name:";
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            serverLabel.Location = new Point(112, 125);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(73, 25);
            serverLabel.TabIndex = 3;
            serverLabel.Text = "Server:";
            // 
            // accessKeyLabel
            // 
            accessKeyLabel.AutoSize = true;
            accessKeyLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            accessKeyLabel.Location = new Point(112, 179);
            accessKeyLabel.Name = "accessKeyLabel";
            accessKeyLabel.Size = new Size(111, 25);
            accessKeyLabel.TabIndex = 4;
            accessKeyLabel.Text = "Access Key:";
            // 
            // secretKeyLabel
            // 
            secretKeyLabel.AutoSize = true;
            secretKeyLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            secretKeyLabel.Location = new Point(112, 236);
            secretKeyLabel.Name = "secretKeyLabel";
            secretKeyLabel.Size = new Size(107, 25);
            secretKeyLabel.TabIndex = 5;
            secretKeyLabel.Text = "Secret Key:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(195, 67);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(150, 31);
            nameTextBox.TabIndex = 6;
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(205, 125);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(150, 31);
            serverTextBox.TabIndex = 7;
            // 
            // accessKeyTextBox
            // 
            accessKeyTextBox.Location = new Point(239, 179);
            accessKeyTextBox.Name = "accessKeyTextBox";
            accessKeyTextBox.Size = new Size(385, 31);
            accessKeyTextBox.TabIndex = 8;
            // 
            // secretKeyTextBox
            // 
            secretKeyTextBox.Location = new Point(239, 236);
            secretKeyTextBox.Name = "secretKeyTextBox";
            secretKeyTextBox.Size = new Size(385, 31);
            secretKeyTextBox.TabIndex = 9;
            // 
            // CreateConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Name = "CreateConfigurationForm";
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