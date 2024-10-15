namespace s3automatebackup.Forms
{
    partial class PrivateKeyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivateKeyForm));
            privateKeyTextBox = new TextBox();
            privateKeyLabel = new Label();
            acceptButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // privateKeyTextBox
            // 
            resources.ApplyResources(privateKeyTextBox, "privateKeyTextBox");
            privateKeyTextBox.Name = "privateKeyTextBox";
            // 
            // privateKeyLabel
            // 
            resources.ApplyResources(privateKeyLabel, "privateKeyLabel");
            privateKeyLabel.Name = "privateKeyLabel";
            // 
            // acceptButton
            // 
            resources.ApplyResources(acceptButton, "acceptButton");
            acceptButton.Name = "acceptButton";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += acceptButton_Click;
            // 
            // cancelButton
            // 
            resources.ApplyResources(cancelButton, "cancelButton");
            cancelButton.Name = "cancelButton";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // PrivateKeyForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cancelButton);
            Controls.Add(acceptButton);
            Controls.Add(privateKeyLabel);
            Controls.Add(privateKeyTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PrivateKeyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox privateKeyTextBox;
        private Label privateKeyLabel;
        private Button acceptButton;
        private Button cancelButton;
    }
}