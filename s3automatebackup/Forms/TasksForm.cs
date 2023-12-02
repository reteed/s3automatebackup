using s3automatebackup.Models;
using s3automatebackup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s3automatebackup.Forms
{
    public partial class TasksForm : Form
    {
        private StorageService storageService = new();
        List<BackupTask> tasks = new();

        public TasksForm()
        {
            InitializeComponent();
            scheduledTaskslistView.View = View.Details;
            scheduledTaskslistView.Columns.Add("Bucket Name", 150, HorizontalAlignment.Left);
            scheduledTaskslistView.Columns.Add("Backup Folder", 300, HorizontalAlignment.Left);
            scheduledTaskslistView.Columns.Add("Scheduled Time", 350, HorizontalAlignment.Left); // Be cautious with sensitive data
            tasks = storageService.LoadTasks();
            PopulateListView(tasks);
        }

        private void PopulateListView(List<BackupTask> tasks)
        {
            scheduledTaskslistView.Items.Clear();

            foreach (BackupTask task in tasks)
            {
                ListViewItem item = new ListViewItem(task.BucketName);
                item.SubItems.Add(task.BackupFolder);
                item.SubItems.Add(task.ScheduledTime.ToString());
                item.Tag = task;
                scheduledTaskslistView.Items.Add(item);
            }
        }

        private void createTaskButton_Click(object sender, EventArgs e)
        {
            List<Configuration> configurations = storageService.LoadConfigurations();
            if(configurations.Count > 0)
            {
                using (CreateTaskForm createTaskForm = new CreateTaskForm())
                {
                    if (createTaskForm.ShowDialog() == DialogResult.OK)
                    {
                        BackupTask newTask = createTaskForm.Task;
                        newTask.Id = tasks.Count + 1;
                        tasks.Add(newTask);
                        storageService.SaveTasks(tasks);
                        PopulateListView(tasks);
                        RescheduleAllTasks();
                    }
                }
            }
            else
            {
                MessageBox.Show("You haven't created any configuration you must do it before creating a backup task.", "Missing Configurations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void scheduledTaskslistView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (scheduledTaskslistView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    listViewContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scheduledTaskslistView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = scheduledTaskslistView.SelectedItems[0];
                BackupTask selectedTask = selectedItem.Tag as BackupTask;
                if (MessageBox.Show("Are you sure you want to delete this task?", "Delete Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    scheduledTaskslistView.Items.Remove(selectedItem);
                    tasks.Remove(selectedTask);
                    storageService.SaveTasks(tasks);
                    PopulateListView(tasks);
                    RescheduleAllTasks();
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scheduledTaskslistView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = scheduledTaskslistView.SelectedItems[0];
                BackupTask selectedTask = (BackupTask)selectedItem.Tag;

                using (CreateTaskForm editForm = new CreateTaskForm(selectedTask))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Replace the old configuration object with the updated one
                        int index = tasks.IndexOf(selectedTask);
                        if (index != -1)
                        {
                            tasks[index] = editForm.Task;
                        }
                        storageService.SaveTasks(tasks);
                        PopulateListView(tasks);
                        RescheduleAllTasks();
                    }
                }
            }
        }

        private void RescheduleAllTasks()
        {
            BackupService backupService = new BackupService();
            backupService.ScheduleTasks();
        }
    }
}
