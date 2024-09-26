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
            configurationsListView = new ListView();
            createConfigurationButton = new Button();
            listViewContextMenuStrip = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            listViewContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // configurationsListView
            // 
            configurationsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            configurationsListView.Location = new Point(34, 48);
            configurationsListView.Margin = new Padding(2);
            configurationsListView.Name = "configurationsListView";
            configurationsListView.Size = new Size(630, 343);
            configurationsListView.TabIndex = 0;
            configurationsListView.UseCompatibleStateImageBehavior = false;
            configurationsListView.MouseClick += listViewConfigurations_MouseClick;
            // 
            // createConfigurationButton
            // 
            createConfigurationButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createConfigurationButton.Location = new Point(584, 11);
            createConfigurationButton.Margin = new Padding(2);
            createConfigurationButton.Name = "createConfigurationButton";
            createConfigurationButton.Size = new Size(80, 30);
            createConfigurationButton.TabIndex = 1;
            createConfigurationButton.Text = "Create";
            createConfigurationButton.UseVisualStyleBackColor = true;
            createConfigurationButton.Click += createConfigurationButton_Click;
            // 
            // listViewContextMenuStrip
            // 
            listViewContextMenuStrip.ImageScalingSize = new Size(24, 24);
            listViewContextMenuStrip.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            listViewContextMenuStrip.Name = "contextMenuStrip1";
            listViewContextMenuStrip.Size = new Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(107, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // ConfigurationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 427);
            Controls.Add(createConfigurationButton);
            Controls.Add(configurationsListView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "ConfigurationsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurations - S3AutomateBackup";
            listViewContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView configurationsListView;
        private Button createConfigurationButton;
        private ContextMenuStrip listViewContextMenuStrip;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
    }
}