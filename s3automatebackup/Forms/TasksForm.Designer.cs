namespace s3automatebackup.Forms
{
    partial class TasksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksForm));
            createTaskButton = new Button();
            scheduledTaskslistView = new ListView();
            listViewContextMenuStrip = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            listViewContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // createTaskButton
            // 
            createTaskButton.Location = new Point(588, 11);
            createTaskButton.Margin = new Padding(2);
            createTaskButton.Name = "createTaskButton";
            createTaskButton.Size = new Size(80, 30);
            createTaskButton.TabIndex = 0;
            createTaskButton.Text = "Create";
            createTaskButton.UseVisualStyleBackColor = true;
            createTaskButton.Click += createTaskButton_Click;
            // 
            // scheduledTaskslistView
            // 
            scheduledTaskslistView.Location = new Point(38, 50);
            scheduledTaskslistView.Margin = new Padding(2);
            scheduledTaskslistView.Name = "scheduledTaskslistView";
            scheduledTaskslistView.Size = new Size(630, 340);
            scheduledTaskslistView.TabIndex = 1;
            scheduledTaskslistView.UseCompatibleStateImageBehavior = false;
            scheduledTaskslistView.MouseClick += scheduledTaskslistView_MouseClick;
            // 
            // listViewContextMenuStrip
            // 
            listViewContextMenuStrip.ImageScalingSize = new Size(24, 24);
            listViewContextMenuStrip.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, deleteToolStripMenuItem });
            listViewContextMenuStrip.Name = "listViewContextMenuStrip";
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
            // TasksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 427);
            Controls.Add(scheduledTaskslistView);
            Controls.Add(createTaskButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "TasksForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tasks - S3AutomateBackup";
            listViewContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button createTaskButton;
        private ListView scheduledTaskslistView;
        private ContextMenuStrip listViewContextMenuStrip;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}