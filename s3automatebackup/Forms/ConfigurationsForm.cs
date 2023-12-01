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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace s3automatebackup.Forms
{
    public partial class ConfigurationsForm : Form
    {
        private StorageService storageService = new();
        List<Configuration> configurations = new();

        public ConfigurationsForm()
        {
            InitializeComponent();
            configurationsListView.View = View.Details;
            configurationsListView.Columns.Add("Name", 150, HorizontalAlignment.Left);
            configurationsListView.Columns.Add("Server", 300, HorizontalAlignment.Left);
            configurationsListView.Columns.Add("Access Key", 350, HorizontalAlignment.Left); // Be cautious with sensitive data
            configurations = storageService.LoadConfigurations();
            PopulateListView(configurations);
        }
        private void PopulateListView(List<Configuration> configurations)
        {
            configurationsListView.Items.Clear();

            foreach (Configuration configuration in configurations)
            {
                ListViewItem item = new ListViewItem(configuration.Name);
                item.SubItems.Add(configuration.Server);
                item.SubItems.Add(configuration.AccessKey);
                item.Tag = configuration;
                configurationsListView.Items.Add(item);
            }
        }

        private void createConfigurationButton_Click(object sender, EventArgs e)
        {
            using (CreateConfigurationForm createConfigurationForm = new CreateConfigurationForm())
            {
                if (createConfigurationForm.ShowDialog() == DialogResult.OK)
                {
                    Configuration newConfiguration = createConfigurationForm.Configuration;
                    newConfiguration.Id = configurations.Count + 1;
                    configurations.Add(newConfiguration);
                    storageService.SaveConfigurations(configurations);
                    PopulateListView(configurations);
                }
            }
        }

        private void listViewConfigurations_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (configurationsListView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    listViewContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configurationsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = configurationsListView.SelectedItems[0];
                Configuration selectedConfig = selectedItem.Tag as Configuration;
                if (MessageBox.Show("Are you sure you want to delete this configuration?", "Delete Configuration", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    configurationsListView.Items.Remove(selectedItem);
                    configurations.Remove(selectedConfig);
                    storageService.SaveConfigurations(configurations);
                    PopulateListView(configurations);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configurationsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = configurationsListView.SelectedItems[0];
                Configuration selectedConfig = (Configuration)selectedItem.Tag;

                using (CreateConfigurationForm editForm = new CreateConfigurationForm(selectedConfig))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Replace the old configuration object with the updated one
                        int index = configurations.IndexOf(selectedConfig);
                        if (index != -1)
                        {
                            configurations[index] = editForm.Configuration;
                        }

                        storageService.SaveConfigurations(configurations);
                        PopulateListView(configurations);
                    }
                }
            }
        }
    }
}