namespace s3automatebackup.Forms
{
    partial class ConfigurationsForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationsForm));
            listViewConfigurations = new ListView();
            createConfigurationButton = new Button();
            listViewContextMenuStrip = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            listViewContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // listViewConfigurations
            // 
            listViewConfigurations.Location = new Point(49, 80);
            listViewConfigurations.Name = "listViewConfigurations";
            listViewConfigurations.Size = new Size(898, 569);
            listViewConfigurations.TabIndex = 0;
            listViewConfigurations.UseCompatibleStateImageBehavior = false;
            listViewConfigurations.MouseClick += listViewConfigurations_MouseClick;
            // 
            // createConfigurationButton
            // 
            createConfigurationButton.Location = new Point(835, 22);
            createConfigurationButton.Name = "createConfigurationButton";
            createConfigurationButton.Size = new Size(112, 34);
            createConfigurationButton.TabIndex = 1;
            createConfigurationButton.Text = "Create";
            createConfigurationButton.UseVisualStyleBackColor = true;
            createConfigurationButton.Click += createConfigurationButton_Click;
            // 
            // listViewContextMenuStrip
            // 
            listViewContextMenuStrip.ImageScalingSize = new Size(24, 24);
            listViewContextMenuStrip.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            listViewContextMenuStrip.Name = "contextMenuStrip1";
            listViewContextMenuStrip.Size = new Size(135, 36);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(134, 32);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // ConfigurationsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(createConfigurationButton);
            Controls.Add(listViewConfigurations);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConfigurationsForm";
            Text = "Configurations - S3AutomateBackup";
            listViewContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewConfigurations;
        private Button createConfigurationButton;
        private ContextMenuStrip listViewContextMenuStrip;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}