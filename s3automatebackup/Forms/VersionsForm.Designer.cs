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
            downloadToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            removeBucketContent = new Button();
            versionsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // configurationLabel
            // 
            configurationLabel.AutoSize = true;
            configurationLabel.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            configurationLabel.Location = new Point(20, 15);
            configurationLabel.Margin = new Padding(2, 0, 2, 0);
            configurationLabel.Name = "configurationLabel";
            configurationLabel.Size = new Size(125, 21);
            configurationLabel.TabIndex = 0;
            configurationLabel.Text = "Configuration:";
            // 
            // configurationComboBox
            // 
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Location = new Point(153, 15);
            configurationComboBox.Margin = new Padding(2);
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.Size = new Size(129, 23);
            configurationComboBox.TabIndex = 1;
            configurationComboBox.SelectedIndexChanged += configurationComboBox_SelectedIndexChanged;
            // 
            // bucketLabel
            // 
            bucketLabel.AutoSize = true;
            bucketLabel.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            bucketLabel.Location = new Point(313, 15);
            bucketLabel.Margin = new Padding(2, 0, 2, 0);
            bucketLabel.Name = "bucketLabel";
            bucketLabel.Size = new Size(69, 21);
            bucketLabel.TabIndex = 2;
            bucketLabel.Text = "Bucket:";
            // 
            // bucketComboBox
            // 
            bucketComboBox.FormattingEnabled = true;
            bucketComboBox.Location = new Point(389, 15);
            bucketComboBox.Margin = new Padding(2);
            bucketComboBox.Name = "bucketComboBox";
            bucketComboBox.Size = new Size(129, 23);
            bucketComboBox.TabIndex = 3;
            bucketComboBox.SelectedIndexChanged += bucketComboBox_SelectedIndexChanged;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(640, 10);
            refreshButton.Margin = new Padding(2);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(80, 30);
            refreshButton.TabIndex = 4;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // versionsTreeView
            // 
            versionsTreeView.Location = new Point(38, 50);
            versionsTreeView.Margin = new Padding(2);
            versionsTreeView.Name = "versionsTreeView";
            versionsTreeView.Size = new Size(682, 363);
            versionsTreeView.TabIndex = 5;
            versionsTreeView.NodeMouseClick += versionsTreeView_NodeMouseClick;
            // 
            // versionsContextMenuStrip
            // 
            versionsContextMenuStrip.ImageScalingSize = new Size(24, 24);
            versionsContextMenuStrip.Items.AddRange(new ToolStripItem[] { restoreToolStripMenuItem, downloadToolStripMenuItem, deleteToolStripMenuItem });
            versionsContextMenuStrip.Name = "versionsContextMenuStrip";
            versionsContextMenuStrip.Size = new Size(129, 70);
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new Size(128, 22);
            restoreToolStripMenuItem.Text = "Restore";
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem
            // 
            downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            downloadToolStripMenuItem.Size = new Size(128, 22);
            downloadToolStripMenuItem.Text = "Download";
            downloadToolStripMenuItem.Click += downloadToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(128, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // removeBucketContent
            // 
            removeBucketContent.Location = new Point(569, 429);
            removeBucketContent.Name = "removeBucketContent";
            removeBucketContent.Size = new Size(151, 36);
            removeBucketContent.TabIndex = 6;
            removeBucketContent.Text = "Remove bucket content";
            removeBucketContent.UseVisualStyleBackColor = true;
            removeBucketContent.Click += removeBucketContent_Click;
            // 
            // VersionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 477);
            Controls.Add(removeBucketContent);
            Controls.Add(versionsTreeView);
            Controls.Add(refreshButton);
            Controls.Add(bucketComboBox);
            Controls.Add(bucketLabel);
            Controls.Add(configurationComboBox);
            Controls.Add(configurationLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
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
        private Button removeBucketContent;
        private ToolStripMenuItem downloadToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}