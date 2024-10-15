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
            smtpHostLabel = new Label();
            smtpHostTextBox = new TextBox();
            smtpPortLabel = new Label();
            smtpPortTextBox = new TextBox();
            smtpUsernameLabel = new Label();
            smtpUsernameTextBox = new TextBox();
            smtpPasswordLabel = new Label();
            smtpPasswordTextBox = new TextBox();
            enableSslCheckBox = new CheckBox();
            successEmailLabel = new Label();
            successEmailTextBox = new TextBox();
            failureEmailLabel = new Label();
            failureEmailTextBox = new TextBox();
            sendTestEmailButton = new Button();
            SuspendLayout();
            // 
            // saveButton
            // 
            resources.ApplyResources(saveButton, "saveButton");
            saveButton.Name = "saveButton";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            resources.ApplyResources(cancelButton, "cancelButton");
            cancelButton.Name = "cancelButton";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // nameLabel
            // 
            resources.ApplyResources(nameLabel, "nameLabel");
            nameLabel.Name = "nameLabel";
            // 
            // serverLabel
            // 
            resources.ApplyResources(serverLabel, "serverLabel");
            serverLabel.Name = "serverLabel";
            // 
            // accessKeyLabel
            // 
            resources.ApplyResources(accessKeyLabel, "accessKeyLabel");
            accessKeyLabel.Name = "accessKeyLabel";
            // 
            // secretKeyLabel
            // 
            resources.ApplyResources(secretKeyLabel, "secretKeyLabel");
            secretKeyLabel.Name = "secretKeyLabel";
            // 
            // nameTextBox
            // 
            resources.ApplyResources(nameTextBox, "nameTextBox");
            nameTextBox.Name = "nameTextBox";
            // 
            // serverTextBox
            // 
            resources.ApplyResources(serverTextBox, "serverTextBox");
            serverTextBox.Name = "serverTextBox";
            // 
            // accessKeyTextBox
            // 
            resources.ApplyResources(accessKeyTextBox, "accessKeyTextBox");
            accessKeyTextBox.Name = "accessKeyTextBox";
            // 
            // secretKeyTextBox
            // 
            resources.ApplyResources(secretKeyTextBox, "secretKeyTextBox");
            secretKeyTextBox.Name = "secretKeyTextBox";
            // 
            // smtpHostLabel
            // 
            resources.ApplyResources(smtpHostLabel, "smtpHostLabel");
            smtpHostLabel.Name = "smtpHostLabel";
            // 
            // smtpHostTextBox
            // 
            resources.ApplyResources(smtpHostTextBox, "smtpHostTextBox");
            smtpHostTextBox.Name = "smtpHostTextBox";
            // 
            // smtpPortLabel
            // 
            resources.ApplyResources(smtpPortLabel, "smtpPortLabel");
            smtpPortLabel.Name = "smtpPortLabel";
            // 
            // smtpPortTextBox
            // 
            resources.ApplyResources(smtpPortTextBox, "smtpPortTextBox");
            smtpPortTextBox.Name = "smtpPortTextBox";
            // 
            // smtpUsernameLabel
            // 
            resources.ApplyResources(smtpUsernameLabel, "smtpUsernameLabel");
            smtpUsernameLabel.Name = "smtpUsernameLabel";
            // 
            // smtpUsernameTextBox
            // 
            resources.ApplyResources(smtpUsernameTextBox, "smtpUsernameTextBox");
            smtpUsernameTextBox.Name = "smtpUsernameTextBox";
            // 
            // smtpPasswordLabel
            // 
            resources.ApplyResources(smtpPasswordLabel, "smtpPasswordLabel");
            smtpPasswordLabel.Name = "smtpPasswordLabel";
            // 
            // smtpPasswordTextBox
            // 
            resources.ApplyResources(smtpPasswordTextBox, "smtpPasswordTextBox");
            smtpPasswordTextBox.Name = "smtpPasswordTextBox";
            // 
            // enableSslCheckBox
            // 
            resources.ApplyResources(enableSslCheckBox, "enableSslCheckBox");
            enableSslCheckBox.Name = "enableSslCheckBox";
            enableSslCheckBox.UseVisualStyleBackColor = true;
            // 
            // successEmailLabel
            // 
            resources.ApplyResources(successEmailLabel, "successEmailLabel");
            successEmailLabel.Name = "successEmailLabel";
            // 
            // successEmailTextBox
            // 
            resources.ApplyResources(successEmailTextBox, "successEmailTextBox");
            successEmailTextBox.Name = "successEmailTextBox";
            // 
            // failureEmailLabel
            // 
            resources.ApplyResources(failureEmailLabel, "failureEmailLabel");
            failureEmailLabel.Name = "failureEmailLabel";
            // 
            // failureEmailTextBox
            // 
            resources.ApplyResources(failureEmailTextBox, "failureEmailTextBox");
            failureEmailTextBox.Name = "failureEmailTextBox";
            // 
            // sendTestEmailButton
            // 
            resources.ApplyResources(sendTestEmailButton, "sendTestEmailButton");
            sendTestEmailButton.Name = "sendTestEmailButton";
            sendTestEmailButton.UseVisualStyleBackColor = true;
            sendTestEmailButton.Click += sendTestEmailButton_Click;
            // 
            // CreateConfigurationForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sendTestEmailButton);
            Controls.Add(failureEmailTextBox);
            Controls.Add(failureEmailLabel);
            Controls.Add(successEmailTextBox);
            Controls.Add(successEmailLabel);
            Controls.Add(enableSslCheckBox);
            Controls.Add(smtpPasswordTextBox);
            Controls.Add(smtpPasswordLabel);
            Controls.Add(smtpUsernameTextBox);
            Controls.Add(smtpUsernameLabel);
            Controls.Add(smtpPortTextBox);
            Controls.Add(smtpPortLabel);
            Controls.Add(smtpHostTextBox);
            Controls.Add(smtpHostLabel);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CreateConfigurationForm";
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
        private Label smtpHostLabel;
        private TextBox smtpHostTextBox;
        private Label smtpPortLabel;
        private TextBox smtpPortTextBox;
        private Label smtpUsernameLabel;
        private TextBox smtpUsernameTextBox;
        private Label smtpPasswordLabel;
        private TextBox smtpPasswordTextBox;
        private CheckBox enableSslCheckBox;
        private Label successEmailLabel;
        private TextBox successEmailTextBox;
        private Label failureEmailLabel;
        private TextBox failureEmailTextBox;
        private Button sendTestEmailButton;
    }
}