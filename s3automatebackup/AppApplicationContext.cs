using s3automatebackup.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace s3automatebackup
{
    public class AppApplicationContext : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        MainForm mainForm = new();
        ResourceManager resourceManager = new("s3automatebackup.AppApplicationContextResources", typeof(AppApplicationContext).Assembly);

        public AppApplicationContext()
        {
            // Configure the context menu (right click)
            notifyIcon.ContextMenuStrip = new ContextMenuStrip()
            {
                Items =
                {
                    new ToolStripMenuItem(resourceManager.GetString("Open"), null, new EventHandler(ShowMainForm), resourceManager.GetString("Open")),
                    new ToolStripMenuItem(resourceManager.GetString("Exit"), null, new EventHandler(Exit), resourceManager.GetString("Exit"))
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

            // Assign the click event
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
        }

        // Handle the left-click on the tray icon
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowMainForm(null, null); // Call method to show MainForm
            }
        }

        private void ShowMainForm(object sender, EventArgs e)
        {
            // Show the MainForm when left-clicked
            if (mainForm.Visible)
            {
                mainForm.Activate();
            }
            else
            {
                mainForm = new();
                mainForm.Show();
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}