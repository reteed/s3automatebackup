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
            privateKeyTextBox.Location = new Point(228, 41);
            privateKeyTextBox.Name = "privateKeyTextBox";
            privateKeyTextBox.PasswordChar = '*';
            privateKeyTextBox.Size = new Size(258, 23);
            privateKeyTextBox.TabIndex = 0;
            // 
            // privateKeyLabel
            // 
            privateKeyLabel.AutoSize = true;
            privateKeyLabel.Location = new Point(61, 45);
            privateKeyLabel.Name = "privateKeyLabel";
            privateKeyLabel.Size = new Size(145, 15);
            privateKeyLabel.TabIndex = 1;
            privateKeyLabel.Text = "Private key for encryption:";
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(322, 118);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(89, 32);
            acceptButton.TabIndex = 2;
            acceptButton.Text = "Accept";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += acceptButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(144, 118);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(89, 32);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // PrivateKeyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 181);
            Controls.Add(cancelButton);
            Controls.Add(acceptButton);
            Controls.Add(privateKeyLabel);
            Controls.Add(privateKeyTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "PrivateKeyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Private Key";
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