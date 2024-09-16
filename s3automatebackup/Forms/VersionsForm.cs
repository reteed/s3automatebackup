using Amazon.S3.Model;
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
    public partial class VersionsForm : Form
    {
        private StorageService storageService = new();
        private S3Service s3Service;
        List<S3Object> allObjects;
        Configuration configuration = new();

        public VersionsForm()
        {
            InitializeComponent();
            PopulateConfigurations();
        }

        private void S3Service_OnDeletionCompleted()
        {
            MessageBox.Show("All objects and versions have been successfully deleted from the bucket.", "Deletion Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void configurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configurationComboBox.SelectedIndex != -1)
            {
                bucketComboBox.SelectedIndex = -1;
                int selectedConfigurationId = (int)configurationComboBox.SelectedValue;

                List<Configuration> configurations = storageService.LoadConfigurations();
                configuration = configurations.Find(c => c.Id == selectedConfigurationId);
                if (configuration != null)
                    PopulateBuckets(configuration);
            }
        }

        private void bucketComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bucketComboBox.SelectedIndex != -1)
            {
                string selectedBucket = (string)bucketComboBox.SelectedValue;
                if (selectedBucket != null)
                {
                    versionsTreeView.Nodes.Clear();
                    GetObjectsFromBucket(s3Service, selectedBucket);
                }
            }
        }

        private void versionsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Check for right-click
            if (e.Button == MouseButtons.Right)
            {
                // Select the clicked node
                versionsTreeView.SelectedNode = e.Node;

                // Check if it's a version node
                if (e.Node.Tag is not null)
                {
                    // Show the context menu
                    versionsContextMenuStrip.Show(versionsTreeView, e.Location);
                }
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = versionsTreeView.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is S3ObjectVersion s3ObjectVersion)
            {
                // Retrieve the S3Object and version details
                S3Object s3Object = allObjects.FindLast(s3 => s3.Key == selectedNode.Parent.Text);
                string versionId = s3ObjectVersion.VersionId;

                // Restore the version
                RestoreVersion(s3Object, versionId);
            }
        }

        private void PopulateConfigurations()
        {
            List<Configuration> configurations = storageService.LoadConfigurations();
            Dictionary<int, string> configurationDictionary = new();
            foreach (Configuration configuration in configurations)
            {
                configurationDictionary.Add(configuration.Id, configuration.Name);
            }

            configurationComboBox.SelectedIndexChanged -= configurationComboBox_SelectedIndexChanged;

            configurationComboBox.DataSource = new BindingSource(configurationDictionary, null);
            configurationComboBox.DisplayMember = "Value"; // Display the configuration name
            configurationComboBox.ValueMember = "Key"; // Use the configuration ID as the underlying value

            configurationComboBox.SelectedIndex = -1;
            configurationComboBox.SelectedIndexChanged += configurationComboBox_SelectedIndexChanged;
        }

        private async void PopulateBuckets(Configuration configuration)
        {
            s3Service = new S3Service(configuration.Server, configuration.AccessKey, configuration.SecretKey, null);
            List<string> buckets = await s3Service.ListAllBucketsAsync();
            bucketComboBox.SelectedIndexChanged -= bucketComboBox_SelectedIndexChanged;
            bucketComboBox.DataSource = new BindingSource(buckets, null);
            bucketComboBox.SelectedIndex = -1;
            bucketComboBox.SelectedIndexChanged += bucketComboBox_SelectedIndexChanged;
            s3Service.OnDeletionCompleted += S3Service_OnDeletionCompleted;
        }

        private async void GetObjectsFromBucket(S3Service s3Service, string bucketName)
        {
            s3Service._bucketName = bucketName;
            allObjects = await s3Service.ListAllObjects(bucketName);
            foreach (var obj in allObjects)
            {
                TreeNode fileNode = new TreeNode(obj.Key);
                fileNode.Tag = "File"; // Assign a simple string tag to indicate this is a file node

                var versions = await s3Service.GetObjectVersions(obj.Key);
                foreach (var version in versions)
                {
                    TreeNode versionNode = new TreeNode($"{version.VersionId} - {version.LastModified}");
                    versionNode.Tag = version; // Storing the version info for easy access later
                    fileNode.Nodes.Add(versionNode);
                }

                versionsTreeView.Nodes.Add(fileNode);
            }
        }

        private async void RestoreVersion(S3Object s3Object, string versionId)
        {
            await s3Service.RestoreVersion(s3Object, versionId);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (bucketComboBox.SelectedIndex != -1)
            {
                string selectedBucket = (string)bucketComboBox.SelectedValue;
                if (selectedBucket != null)
                {
                    versionsTreeView.Nodes.Clear();
                    GetObjectsFromBucket(s3Service, selectedBucket);
                }
            }
        }

        private async void removeBucketContent_Click(object sender, EventArgs e)
        {
            if (bucketComboBox.SelectedIndex != -1)
            {
                string selectedBucket = (string)bucketComboBox.SelectedValue;
                if (selectedBucket != null)
                {
                    // Confirm the deletion
                    DialogResult result = MessageBox.Show(
                        $"Are you sure you want to delete all objects and versions from the bucket '{selectedBucket}'?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Call the S3Service to delete all objects and versions
                        await s3Service.DeleteAllObjectsAndVersions(selectedBucket);
                    }
                }
            }
        }

        private async void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = versionsTreeView.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is S3ObjectVersion s3ObjectVersion)
            {
                // Retrieve the S3Object and version details
                S3Object s3Object = allObjects.FindLast(s3 => s3.Key == selectedNode.Parent.Text);
                string versionId = s3ObjectVersion.VersionId;

                // Get the user's Downloads folder
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                // Create the full download path for the file in the Downloads folder
                string downloadFilePath = Path.Combine(downloadsPath, s3Object.Key);

                try
                {
                    // Download the version
                    await s3Service.DownloadVersion(s3Object.Key, versionId, downloadFilePath);
                    MessageBox.Show($"Version {versionId} of {s3Object.Key} downloaded successfully to {downloadsPath}.",
                                    "Download Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during download: {ex.Message}", "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = versionsTreeView.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is S3ObjectVersion s3ObjectVersion)
            {
                // Retrieve the S3Object and version details
                S3Object s3Object = allObjects.FindLast(s3 => s3.Key == selectedNode.Parent.Text);
                string versionId = s3ObjectVersion.VersionId;

                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to delete version {versionId} of {s3Object.Key}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // Remove the version
                    await s3Service.DeleteVersion(s3Object.Key, versionId);
                    MessageBox.Show($"Version {versionId} of {s3Object.Key} deleted successfully.");

                    // Remove the node from the TreeView
                    versionsTreeView.Nodes.Remove(selectedNode);
                }
            }
        }
    }
}