using Amazon.S3.Model;
using S3AutomateBackup;
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

namespace s3automatebackup
{
    public partial class VersionsForm : Form
    {
        List<S3Object> allObjects;
        S3Service globalS3Service;
        public VersionsForm()
        {
            InitializeComponent();
            PopulateTreeView();
        }

        private async void PopulateTreeView()
        {
            SecureFormStorage storage = new();
            string loadedData = storage.LoadFormFields();
            if (loadedData != null)
            {
                string[] fieldValues = loadedData.Split(',');
                S3Service s3Service = new S3Service(fieldValues[0], fieldValues[1], fieldValues[2], fieldValues[3]);
                globalS3Service = s3Service;
                PopulateBucketsComboBox(s3Service);
            }
        }

        private async void PopulateBucketsComboBox(S3Service s3Service)
        {
            Dictionary<string, string> buckets = await s3Service.ListAllBucketsAsync();
            bucketListComboBox.SelectedIndexChanged -= bucketListComboBox_SelectedIndexChanged;
            bucketListComboBox.DataSource = new BindingSource(buckets, null);
            bucketListComboBox.SelectedIndex = -1;
            bucketListComboBox.SelectedIndexChanged += bucketListComboBox_SelectedIndexChanged;
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

        private async void RestoreVersion(S3Object s3Object, string versionId)
        {
            SecureFormStorage storage = new();
            string loadedData = storage.LoadFormFields();
            if (loadedData != null)
            {
                string[] fieldValues = loadedData.Split(',');
                S3Service s3Uploader = new S3Service(fieldValues[0], fieldValues[1], fieldValues[2], fieldValues[3]);

                await s3Uploader.RestoreVersion(s3Object, versionId);
            }
        }

        private void bucketListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBucket = (string)bucketListComboBox.SelectedValue;
            if (selectedBucket != null)
            {
                versionsTreeView.Nodes.Clear();
                GetObjectsFromBucket(globalS3Service, selectedBucket);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            string selectedBucket = (string)bucketListComboBox.SelectedValue;
            if (selectedBucket != null)
            {
                versionsTreeView.Nodes.Clear();
                GetObjectsFromBucket(globalS3Service, selectedBucket);
            }
        }
    }
}