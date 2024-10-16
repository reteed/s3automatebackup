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
            tasksContextMenuStrip = new ContextMenuStrip(components);
            editTaskStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            versionsContextMenuStrip = new ContextMenuStrip(components);
            restoreToolStripMenuItem = new ToolStripMenuItem();
            downloadToolStripMenuItem = new ToolStripMenuItem();
            deleteVersionToolStripMenuItem = new ToolStripMenuItem();
            configurationsContextMenuStrip = new ContextMenuStrip(components);
            editConfigurationToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem1 = new ToolStripMenuItem();
            mainTabControl.SuspendLayout();
            configurationsTabPage.SuspendLayout();
            tasksTabPage.SuspendLayout();
            versionsTabPage.SuspendLayout();
            tasksContextMenuStrip.SuspendLayout();
            versionsContextMenuStrip.SuspendLayout();
            configurationsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // mainTabControl
            // 
            resources.ApplyResources(mainTabControl, "mainTabControl");
            mainTabControl.Controls.Add(configurationsTabPage);
            mainTabControl.Controls.Add(tasksTabPage);
            mainTabControl.Controls.Add(versionsTabPage);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            // 
            // configurationsTabPage
            // 
            resources.ApplyResources(configurationsTabPage, "configurationsTabPage");
            configurationsTabPage.Controls.Add(createConfigurationButton);
            configurationsTabPage.Controls.Add(configurationsListView);
            configurationsTabPage.Name = "configurationsTabPage";
            configurationsTabPage.UseVisualStyleBackColor = true;
            // 
            // createConfigurationButton
            // 
            resources.ApplyResources(createConfigurationButton, "createConfigurationButton");
            createConfigurationButton.Name = "createConfigurationButton";
            createConfigurationButton.UseVisualStyleBackColor = true;
            createConfigurationButton.Click += createConfigurationButton_Click;
            // 
            // configurationsListView
            // 
            resources.ApplyResources(configurationsListView, "configurationsListView");
            configurationsListView.Name = "configurationsListView";
            configurationsListView.UseCompatibleStateImageBehavior = false;
            configurationsListView.MouseDoubleClick += listViewConfigurations_MouseDoubleClick;
            configurationsListView.MouseUp += listViewConfigurations_MouseUp;
            // 
            // tasksTabPage
            // 
            resources.ApplyResources(tasksTabPage, "tasksTabPage");
            tasksTabPage.Controls.Add(scheduledTaskslistView);
            tasksTabPage.Controls.Add(createTaskButton);
            tasksTabPage.Name = "tasksTabPage";
            tasksTabPage.UseVisualStyleBackColor = true;
            // 
            // scheduledTaskslistView
            // 
            resources.ApplyResources(scheduledTaskslistView, "scheduledTaskslistView");
            scheduledTaskslistView.Name = "scheduledTaskslistView";
            scheduledTaskslistView.UseCompatibleStateImageBehavior = false;
            scheduledTaskslistView.MouseClick += scheduledTaskslistView_MouseClick;
            scheduledTaskslistView.MouseDoubleClick += scheduledTaskslistView_MouseDoubleClick;
            // 
            // createTaskButton
            // 
            resources.ApplyResources(createTaskButton, "createTaskButton");
            createTaskButton.Name = "createTaskButton";
            createTaskButton.UseVisualStyleBackColor = true;
            createTaskButton.Click += createTaskButton_Click;
            // 
            // versionsTabPage
            // 
            resources.ApplyResources(versionsTabPage, "versionsTabPage");
            versionsTabPage.Controls.Add(removeBucketContent);
            versionsTabPage.Controls.Add(versionsTreeView);
            versionsTabPage.Controls.Add(refreshButton);
            versionsTabPage.Controls.Add(bucketComboBox);
            versionsTabPage.Controls.Add(bucketLabel);
            versionsTabPage.Controls.Add(configurationComboBox);
            versionsTabPage.Controls.Add(configurationLabel);
            versionsTabPage.Name = "versionsTabPage";
            versionsTabPage.UseVisualStyleBackColor = true;
            // 
            // removeBucketContent
            // 
            resources.ApplyResources(removeBucketContent, "removeBucketContent");
            removeBucketContent.Name = "removeBucketContent";
            removeBucketContent.UseVisualStyleBackColor = true;
            removeBucketContent.Click += removeBucketContent_Click;
            // 
            // versionsTreeView
            // 
            resources.ApplyResources(versionsTreeView, "versionsTreeView");
            versionsTreeView.Name = "versionsTreeView";
            versionsTreeView.NodeMouseClick += versionsTreeView_NodeMouseClick;
            // 
            // refreshButton
            // 
            resources.ApplyResources(refreshButton, "refreshButton");
            refreshButton.Name = "refreshButton";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // bucketComboBox
            // 
            resources.ApplyResources(bucketComboBox, "bucketComboBox");
            bucketComboBox.FormattingEnabled = true;
            bucketComboBox.Name = "bucketComboBox";
            bucketComboBox.SelectedIndexChanged += bucketComboBox_SelectedIndexChanged;
            // 
            // bucketLabel
            // 
            resources.ApplyResources(bucketLabel, "bucketLabel");
            bucketLabel.Name = "bucketLabel";
            // 
            // configurationComboBox
            // 
            resources.ApplyResources(configurationComboBox, "configurationComboBox");
            configurationComboBox.FormattingEnabled = true;
            configurationComboBox.Name = "configurationComboBox";
            configurationComboBox.SelectedIndexChanged += configurationComboBox_SelectedIndexChanged;
            // 
            // configurationLabel
            // 
            resources.ApplyResources(configurationLabel, "configurationLabel");
            configurationLabel.Name = "configurationLabel";
            // 
            // tasksContextMenuStrip
            // 
            resources.ApplyResources(tasksContextMenuStrip, "tasksContextMenuStrip");
            tasksContextMenuStrip.ImageScalingSize = new Size(24, 24);
            tasksContextMenuStrip.Items.AddRange(new ToolStripItem[] { editTaskStripMenuItem, deleteToolStripMenuItem });
            tasksContextMenuStrip.Name = "contextMenuStrip1";
            // 
            // editTaskStripMenuItem
            // 
            resources.ApplyResources(editTaskStripMenuItem, "editTaskStripMenuItem");
            editTaskStripMenuItem.Name = "editTaskStripMenuItem";
            editTaskStripMenuItem.Click += editTaskToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(deleteToolStripMenuItem, "deleteToolStripMenuItem");
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Click += deleteTaskToolStripMenuItem_Click;
            // 
            // versionsContextMenuStrip
            // 
            resources.ApplyResources(versionsContextMenuStrip, "versionsContextMenuStrip");
            versionsContextMenuStrip.ImageScalingSize = new Size(24, 24);
            versionsContextMenuStrip.Items.AddRange(new ToolStripItem[] { restoreToolStripMenuItem, downloadToolStripMenuItem, deleteVersionToolStripMenuItem });
            versionsContextMenuStrip.Name = "versionsContextMenuStrip";
            // 
            // restoreToolStripMenuItem
            // 
            resources.ApplyResources(restoreToolStripMenuItem, "restoreToolStripMenuItem");
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            // 
            // downloadToolStripMenuItem
            // 
            resources.ApplyResources(downloadToolStripMenuItem, "downloadToolStripMenuItem");
            downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            downloadToolStripMenuItem.Click += downloadToolStripMenuItem_Click;
            // 
            // deleteVersionToolStripMenuItem
            // 
            resources.ApplyResources(deleteVersionToolStripMenuItem, "deleteVersionToolStripMenuItem");
            deleteVersionToolStripMenuItem.Name = "deleteVersionToolStripMenuItem";
            deleteVersionToolStripMenuItem.Click += deleteVersionToolStripMenuItem_Click;
            // 
            // configurationsContextMenuStrip
            // 
            resources.ApplyResources(configurationsContextMenuStrip, "configurationsContextMenuStrip");
            configurationsContextMenuStrip.Items.AddRange(new ToolStripItem[] { editConfigurationToolStripMenuItem, deleteToolStripMenuItem1 });
            configurationsContextMenuStrip.Name = "editConfigurationContextMenuStrip";
            // 
            // editConfigurationToolStripMenuItem
            // 
            resources.ApplyResources(editConfigurationToolStripMenuItem, "editConfigurationToolStripMenuItem");
            editConfigurationToolStripMenuItem.Name = "editConfigurationToolStripMenuItem";
            editConfigurationToolStripMenuItem.Click += editConfigurationToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem1
            // 
            resources.ApplyResources(deleteToolStripMenuItem1, "deleteToolStripMenuItem1");
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.Click += deleteConfigurationToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainTabControl);
            Name = "MainForm";
            mainTabControl.ResumeLayout(false);
            configurationsTabPage.ResumeLayout(false);
            tasksTabPage.ResumeLayout(false);
            versionsTabPage.ResumeLayout(false);
            versionsTabPage.PerformLayout();
            tasksContextMenuStrip.ResumeLayout(false);
            versionsContextMenuStrip.ResumeLayout(false);
            configurationsContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainTabControl;
        private TabPage configurationsTabPage;
        private TabPage tasksTabPage;
        private TabPage versionsTabPage;
        private Button createConfigurationButton;
        private ListView configurationsListView;
        private ContextMenuStrip tasksContextMenuStrip;
        private ToolStripMenuItem editTaskStripMenuItem;
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
        private ContextMenuStrip configurationsContextMenuStrip;
        private ToolStripMenuItem editConfigurationToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem1;
    }
}