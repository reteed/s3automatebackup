namespace s3automatebackup
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
            versionsTreeView = new TreeView();
            versionsContextMenuStrip = new ContextMenuStrip(components);
            restoreToolStripMenuItem = new ToolStripMenuItem();
            bucketListComboBox = new ComboBox();
            bucketLabel = new Label();
            refreshButton = new Button();
            versionsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // versionsTreeView
            // 
            versionsTreeView.Location = new Point(36, 96);
            versionsTreeView.Name = "versionsTreeView";
            versionsTreeView.Size = new Size(1080, 587);
            versionsTreeView.TabIndex = 0;
            versionsTreeView.NodeMouseClick += versionsTreeView_NodeMouseClick;
            // 
            // versionsContextMenuStrip
            // 
            versionsContextMenuStrip.ImageScalingSize = new Size(24, 24);
            versionsContextMenuStrip.Items.AddRange(new ToolStripItem[] { restoreToolStripMenuItem });
            versionsContextMenuStrip.Name = "contextMenuStrip1";
            versionsContextMenuStrip.Size = new Size(144, 36);
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new Size(143, 32);
            restoreToolStripMenuItem.Text = "Restore";
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            // 
            // bucketListComboBox
            // 
            bucketListComboBox.DisplayMember = "Value";
            bucketListComboBox.FormattingEnabled = true;
            bucketListComboBox.Location = new Point(150, 33);
            bucketListComboBox.Name = "bucketListComboBox";
            bucketListComboBox.Size = new Size(182, 33);
            bucketListComboBox.TabIndex = 1;
            bucketListComboBox.ValueMember = "Key";
            bucketListComboBox.SelectedIndexChanged += bucketListComboBox_SelectedIndexChanged;
            // 
            // bucketLabel
            // 
            bucketLabel.AutoSize = true;
            bucketLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bucketLabel.Location = new Point(36, 30);
            bucketLabel.Name = "bucketLabel";
            bucketLabel.Size = new Size(98, 32);
            bucketLabel.TabIndex = 2;
            bucketLabel.Text = "Bucket:";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(1004, 33);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(112, 34);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // VersionsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(refreshButton);
            Controls.Add(bucketLabel);
            Controls.Add(bucketListComboBox);
            Controls.Add(versionsTreeView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VersionsForm";
            Text = "Versions - S3AutomateBackup";
            versionsContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView versionsTreeView;
        private ContextMenuStrip versionsContextMenuStrip;
        private ToolStripMenuItem restoreToolStripMenuItem;
        private ComboBox bucketListComboBox;
        private Label bucketLabel;
        private Button refreshButton;
    }
}