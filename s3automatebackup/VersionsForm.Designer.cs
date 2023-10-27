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
            versionsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // versionsTreeView
            // 
            versionsTreeView.Location = new Point(-1, -3);
            versionsTreeView.Name = "versionsTreeView";
            versionsTreeView.Size = new Size(1148, 755);
            versionsTreeView.TabIndex = 0;
            versionsTreeView.NodeMouseClick += versionsTreeView_NodeMouseClick;
            // 
            // versionsContextMenuStrip
            // 
            versionsContextMenuStrip.ImageScalingSize = new Size(24, 24);
            versionsContextMenuStrip.Items.AddRange(new ToolStripItem[] { restoreToolStripMenuItem });
            versionsContextMenuStrip.Name = "contextMenuStrip1";
            versionsContextMenuStrip.Size = new Size(241, 69);
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new Size(240, 32);
            restoreToolStripMenuItem.Text = "Restore";
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            // 
            // VersionsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(versionsTreeView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VersionsForm";
            Text = "Versions - S3AutomateBackup";
            versionsContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView versionsTreeView;
        private ContextMenuStrip versionsContextMenuStrip;
        private ToolStripMenuItem restoreToolStripMenuItem;
    }
}