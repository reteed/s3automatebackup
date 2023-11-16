﻿using Amazon.S3.Model;
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

        public VersionsForm()
        {
            InitializeComponent();
            PopulateConfigurations();

        }

        private void configurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configurationComboBox.SelectedIndex != -1)
            {
                bucketComboBox.SelectedIndex = -1;
                int selectedConfigurationId = (int)configurationComboBox.SelectedValue;

                List<Configuration> configurations = storageService.LoadConfigurations();
                Configuration configuration = configurations.Find(c => c.Id == selectedConfigurationId);
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
        }

        private async void GetObjectsFromBucket(S3Service s3Service, string bucketName)
        {
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
    }
}
