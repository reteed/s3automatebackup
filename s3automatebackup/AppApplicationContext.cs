using s3automatebackup.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3automatebackup
{
    public class AppApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        public AppApplicationContext()
        {
            notifyIcon.ContextMenuStrip = new ContextMenuStrip()
            {
                Items =
                {
                    new ToolStripMenuItem("Tasks", null, new EventHandler(ShowTasks), "Tasks"),
                    new ToolStripMenuItem("Configurations", null, new EventHandler(ShowConfigurations), "Configurations"),
                    new ToolStripMenuItem("Versions", null, new EventHandler(ShowVersions), "Versions"),
                    new ToolStripMenuItem("Exit", null, new EventHandler(Exit), "Exit")
                }
            };
            string iconPath = Path.Combine(Application.StartupPath, "cloud.ico");
            if (File.Exists(iconPath))
            {
                notifyIcon.Icon = new Icon(iconPath);
            }
            else
            {
                notifyIcon.Icon = SystemIcons.Application; // Default system icon as a fallback
            }

            notifyIcon.Visible = true;
        }
        private void ShowTasks(object sender, EventArgs e)
        {
            TasksForm tasksForm = new();
            // If we are already showing the window, merely focus it.
            if (tasksForm.Visible)
            {
                tasksForm.Activate();
            }
            else
            {
                tasksForm.Show();
            }
        }
        private void ShowConfigurations(object sender, EventArgs e)
        {
            ConfigurationsForm configurationForm = new();
            // If we are already showing the window, merely focus it.
            if (configurationForm.Visible)
            {
                configurationForm.Activate();
            }
            else
            {
                configurationForm.Show();
            }
        }
        private void ShowVersions(object sender, EventArgs e)
        {
            VersionsForm versionsForm = new();
            // If we are already showing the window, merely focus it.
            if (versionsForm.Visible)
            {
                versionsForm.Activate();
            }
            else
            {
                versionsForm.Show();
            }
        }
        private void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
