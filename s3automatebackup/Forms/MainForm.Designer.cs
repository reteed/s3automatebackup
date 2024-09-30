namespace s3automatebackup.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainTabControl = new TabControl();
            configurationsTabPage = new TabPage();
            createConfigurationButton = new Button();
            configurationsListView = new ListView();
            tasksTabPage = new TabPage();
            scheduledTaskslistView = new ListView();
            createTaskButton = new Button();
            versionsTabPage = new TabPage();
            removeBucketContent = new Button();
            versionsTreeView = new TreeView();
            refreshButton = new Button();
            bucketComboBox = new ComboBox();
            bucketLabel = new Label();
            configurationComboBox = new ComboBox();
            configurationLabel = new Label();
            listViewContextMenuStrip = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            versionsContextMenuStrip = new ContextMenuStrip(components);
            restoreToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem = new ToolStripMenuItem();
            deleteVersionToolStripMenuItem = new ToolStripMenuItem();
            mainTabControl.SuspendLayout();
            configurationsTabPage.SuspendLayout();
            tasksTabPage.SuspendLayout();
            versionsTabPage.SuspendLayout();
            listViewContextMenuStrip.SuspendLayout();
            versionsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainTabControl
            // 
            mainTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainTabControl.Controls.Add(configurationsTabPage);
            mainTabControl.Controls.Add(tasksTabPage);
            mainTabControl.Controls.Add(versionsTabPage);
            mainTabControl.Location = new Point(-2, 1);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(802, 450);
            mainTabControl.TabIndex = 0;
            // 
            // configurationsTabPage
            // 
            configurationsTabPage.Controls.Add(createConfigurationButton);
            configurationsTabPage.Controls.Add(configurationsListView);
            configurationsTabPage.Location = new Point(4, 24);
            configurationsTabPage.Name = "configurationsTabPage";
            configurationsTabPage.Padding = new Padding(3);
            configurationsTabPage.Size = new Size(794, 422);
            configurationsTabPage.TabIndex = 0;
            configurationsTabPage.Text = "Configurations";
            configurationsTabPage.UseVisualStyleBackColor = true;
            // 
            // createConfigurationButton
            // 
            createConfigurationButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createConfigurationButton.Location = new Point(667, 15);
            createConfigurationButton.Margin = new Padding(2);
            createConfigurationButton.Name = "createConfigurationButton";
            createConfigurationButton.Size = new Size(80, 30);
            createConfigurationButton.TabIndex = 3;
            createConfigurationButton.Text = "Create";
            createConfigurationButton.UseVisualStyleBackColor = true;
            createConfigurationButton.Click += createConfigurationButton_Click;
            // 
            // configurationsListView
            // 
            configurationsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            configurationsListView.Location = new Point(47, 58);
            configurationsListView.Margin = new Padding(2);
            configurationsListView.Name = "configurationsListView";
            configurationsListView.Size = new Size(700, 343);
            configurationsListView.TabIndex = 2;
            configurationsListView.UseCompatibleStateImageBehavior = false;
            configurationsListView.MouseDoubleClick += listViewConfigurations_MouseDoubleClick;
            configurationsListView.MouseUp += listViewConfigurations_MouseUp;
            // 
            // tasksTabPage
            // 
            tasksTabPage.Controls.Add(scheduledTaskslistView);
            tasksTabPage.Controls.Add(createTaskButton);
            tasksTabPage.Location = new Point(4, 24);
            tasksTabPage.Name = "tasksTabPage";
            tasksTabPage.Padding = new Padding(3);
            tasksTabPage.Size = new Size(794, 422);
            tasksTabPage.TabIndex = 1;
            tasksTabPage.Text = "Tasks";
            tasksTabPage.UseVisualStyleBackColor = true;
            // 
            // scheduledTaskslistView
            // 
            scheduledTaskslistView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scheduledTaskslistView.Location = new Point(47, 61);
            scheduledTaskslistView.Margin = new Padding(2);
            scheduledTaskslistView.Name = "scheduledTaskslistView";
            scheduledTaskslistView.Size = new Size(700, 340);
            scheduledTaskslistView.TabIndex = 3;
            scheduledTaskslistView.UseCompatibleStateImageBehavior = false;
            scheduledTaskslistView.MouseClick += scheduledTaskslistView_MouseClick;
            // 
            // createTaskButton
            // 
            createTaskButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createTaskButton.Location = new Point(667, 17);
            createTaskButton.Margin = new Padding(2);
            createTaskButton.Name = "createTaskButton";
            createTaskButton.Size = new Size(80, 30);
            createTaskButton.TabIndex = 2;
            createTaskButton.Text = "Create";
            createTaskButton.UseVisualStyleBackColor = true;
            createTaskButton.Click += createTaskButton_Click;
            // 
            // versionsTabPage
            // 
            versionsTabPage.Controls.Add(removeBucketContent);
            versionsTabPage.Controls.Add(versionsTreeView);
            versionsTabPage.Controls.Add(refreshButton);
            versionsTabPage.Controls.Add(bucketComboBox);
            versionsTabPage.Controls.Add(bucketLabel);
            versionsTabPage.Controls.Add(configurationComboBox);
            versionsTabPage.Controls.Add(configurationLabel);
            versionsTabPage.Location = new Point(4, 24);
            versionsTabPage.Name = "versionsTabPage";
            versionsTabPage.Padding = new Padding(3);
            versionsTabPage.Size = new Size(794, 422);
            versionsTabPage.TabIndex = 2;
            versionsTabPage.Text = "Versions";
            versionsTabPage.UseVisualStyleBackColor = true;
            // 
            // removeBucketContent
            // 
            removeBucketContent.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            removeBucketContent.Location = new Point(596, 378);
            removeBucketContent.Name = "removeBucketContent";
            removeBucketContent.Size = new Size(151, 36);
            removeBucketContent.TabIndex = 13;
            removeBucketContent.Text = "Remove bucket content";
            removeBucketContent.UseVisualStyleBackColor = true;
            removeBucketContent.Click += removeBucketContent_Click;
            // 
            // versionsTreeView
            // 
            versionsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            versionsTreeView.Location = new Point(47, 48);
            versionsTreeView.Margin = new Padding(2);
            versionsTreeView.Name = "versionsTreeView";
            versionsTreeView.Size = new Size(700, 320);
            versionsTreeView.TabIndex = 12;
            versionsTreeView.NodeMouseClick += versionsTreeView_NodeMouseClick;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshButton.Location = new Point(649, 8);
            refreshButton.Margin = new Padding(2);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(80, 30);
            refreshButton.TabIndex = 11;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // bucketComboBox
            // 
            bucketComboBox.FormattingEnabled = true;
            bucketComboBox.Location = new Point(416, 13);
            bucketComboBox.Margin = new Padding(2);
            bucketComboBox.Name = "bucketComboBox";
            bucketComboBox.Size = new Size(129, 23);
            bucketComboBox.TabIndex = 10;
            bucketComboBox.SelectedIndexChanged += bucketComboBox_SelectedIndexChanged;
            // 
            // bucketLabel
            // 
            bucketLabel.AutoSize = true;
            bucketLabel.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            bucketLabel.Location = new Point(343, 13);
            bucketLabel.Margin = new Padding(2, 0, 2, 0);
            bucketLabel.Name = "bucketLabel";
            bucketLabel.Size = new Size(69, 21);
            bucketLabel.TabIndex = 9;
            bucketLabel.Text = "Bucket:";
            // 
            // configurationComboBox
            // 
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Location = new Point(176, 11);
            configurationComboBox.Margin = new Padding(2);
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.Size = new Size(129, 23);
            configurationComboBox.TabIndex = 8;
            configurationComboBox.SelectedIndexChanged += configurationComboBox_SelectedIndexChanged;
            // 
            // configurationLabel
            // 
            configurationLabel.AutoSize = true;
            configurationLabel.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold);
            configurationLabel.Location = new Point(47, 13);
            configurationLabel.Margin = new Padding(2, 0, 2, 0);
            configurationLabel.Name = "configurationLabel";
            configurationLabel.Size = new Size(125, 21);
            configurationLabel.TabIndex = 7;
            configurationLabel.Text = "Configuration:";
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
            editToolStripMenuItem.Click += editTaskToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteTaskToolStripMenuItem_Click;
            // 
            // versionsContextMenuStrip
            // 
            versionsContextMenuStrip.ImageScalingSize = new Size(24, 24);
            versionsContextMenuStrip.Items.AddRange(new ToolStripItem[] { restoreToolStripMenuItem, downloadToolStripMenuItem, deleteVersionToolStripMenuItem });
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
            // deleteVersionToolStripMenuItem
            // 
            deleteVersionToolStripMenuItem.Name = "deleteVersionToolStripMenuItem";
            deleteVersionToolStripMenuItem.Size = new Size(128, 22);
            deleteVersionToolStripMenuItem.Text = "Delete";
            deleteVersionToolStripMenuItem.Click += deleteVersionToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainTabControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "S3AutomateBackup";
            mainTabControl.ResumeLayout(false);
            configurationsTabPage.ResumeLayout(false);
            tasksTabPage.ResumeLayout(false);
            versionsTabPage.ResumeLayout(false);
            versionsTabPage.PerformLayout();
            listViewContextMenuStrip.ResumeLayout(false);
            versionsContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainTabControl;
        private TabPage configurationsTabPage;
        private TabPage tasksTabPage;
        private TabPage versionsTabPage;
        private Button createConfigurationButton;
        private ListView configurationsListView;
        private ContextMenuStrip listViewContextMenuStrip;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button removeBucketContent;
        private TreeView versionsTreeView;
        private Button refreshButton;
        private ComboBox bucketComboBox;
        private Label bucketLabel;
        private ComboBox configurationComboBox;
        private Label configurationLabel;
        private ContextMenuStrip versionsContextMenuStrip;
        private ToolStripMenuItem restoreToolStripMenuItem;
        private ToolStripMenuItem downloadToolStripMenuItem;
        private ToolStripMenuItem deleteVersionToolStripMenuItem;
        private ListView scheduledTaskslistView;
        private Button createTaskButton;
    }
}