namespace s3automatebackup.Forms
{
    partial class VersionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionsForm));
            configurationLabel = new Label();
            configurationComboBox = new ComboBox();
            bucketLabel = new Label();
            bucketComboBox = new ComboBox();
            refreshButton = new Button();
            versionsTreeView = new TreeView();
            versionsContextMenuStrip = new ContextMenuStrip(components);
            restoreToolStripMenuItem = new ToolStripMenuItem();
            versionsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // configurationLabel
            // 
            configurationLabel.AutoSize = true;
            configurationLabel.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            configurationLabel.Location = new Point(29, 33);
            configurationLabel.Name = "configurationLabel";
            configurationLabel.Size = new Size(184, 32);
            configurationLabel.TabIndex = 0;
            configurationLabel.Text = "Configuration:";
            // 
            // configurationComboBox
            // 
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Location = new Point(219, 36);
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.Size = new Size(182, 33);
            configurationComboBox.TabIndex = 1;
            configurationComboBox.SelectedIndexChanged += configurationComboBox_SelectedIndexChanged;
            // 
            // bucketLabel
            // 
            bucketLabel.AutoSize = true;
            bucketLabel.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bucketLabel.Location = new Point(447, 37);
            bucketLabel.Name = "bucketLabel";
            bucketLabel.Size = new Size(103, 32);
            bucketLabel.TabIndex = 2;
            bucketLabel.Text = "Bucket:";
            // 
            // bucketComboBox
            // 
            bucketComboBox.FormattingEnabled = true;
            bucketComboBox.Location = new Point(556, 40);
            bucketComboBox.Name = "bucketComboBox";
            bucketComboBox.Size = new Size(182, 33);
            bucketComboBox.TabIndex = 3;
            bucketComboBox.SelectedIndexChanged += bucketComboBox_SelectedIndexChanged;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(846, 40);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(112, 34);
            refreshButton.TabIndex = 4;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // versionsTreeView
            // 
            versionsTreeView.Location = new Point(31, 112);
            versionsTreeView.Name = "versionsTreeView";
            versionsTreeView.Size = new Size(927, 564);
            versionsTreeView.TabIndex = 5;
            versionsTreeView.NodeMouseClick += versionsTreeView_NodeMouseClick;
            // 
            // versionsContextMenuStrip
            // 
            versionsContextMenuStrip.ImageScalingSize = new Size(24, 24);
            versionsContextMenuStrip.Items.AddRange(new ToolStripItem[] { restoreToolStripMenuItem });
            versionsContextMenuStrip.Name = "versionsContextMenuStrip";
            versionsContextMenuStrip.Size = new Size(144, 36);
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new Size(143, 32);
            restoreToolStripMenuItem.Text = "Restore";
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            // 
            // VersionsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(versionsTreeView);
            Controls.Add(refreshButton);
            Controls.Add(bucketComboBox);
            Controls.Add(bucketLabel);
            Controls.Add(configurationComboBox);
            Controls.Add(configurationLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VersionsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Versions - S3AutomateBackup";
            versionsContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label configurationLabel;
        private ComboBox configurationComboBox;
        private Label bucketLabel;
        private ComboBox bucketComboBox;
        private Button refreshButton;
        private TreeView versionsTreeView;
        private ContextMenuStrip versionsContextMenuStrip;
        private ToolStripMenuItem restoreToolStripMenuItem;
    }
}