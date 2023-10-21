using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3AutomateBackup
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
                    new ToolStripMenuItem("Configuration", null, new EventHandler(ShowConfiguration), "Configuration"),
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
        private void ShowConfiguration(object sender, EventArgs e)
        {
            ConfigurationForm configuration = new();
            // If we are already showing the window, merely focus it.
            if (configuration.Visible)
            {
                configuration.Activate();
            }
            else
            {
                configuration.Show();
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
