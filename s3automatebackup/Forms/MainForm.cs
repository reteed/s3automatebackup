using Amazon.S3.Model;
using s3automatebackup.Models;
using s3automatebackup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace s3automatebackup.Forms
{
    public partial class MainForm : Form
    {
        private StorageService storageService = new();
        List<Configuration> configurations = new();
        private bool isDoubleClick = false;
        List<BackupTask> tasks = new();
        private S3Service s3Service;
        List<S3Object> allObjects;
        Configuration configuration = new();

        public MainForm()
        {
            InitializeComponent();
            #region Configurations Initialization
            configurationsListView.View = View.Details;
            configurationsListView.Columns.Add("Name", 150, HorizontalAlignment.Left);
            configurationsListView.Columns.Add("Server", 300, HorizontalAlignment.Left);
            configurationsListView.Columns.Add("Access Key", 350, HorizontalAlignment.Left); // Be cautious with sensitive data
            configurations = storageService.LoadConfigurations();
            PopulateListView(configurations);
            #endregion
            #region Tasks Initialization
            scheduledTaskslistView.View = View.Details;
            scheduledTaskslistView.Columns.Add("Bucket Name", 150, HorizontalAlignment.Left);
            scheduledTaskslistView.Columns.Add("Backup Folder", 300, HorizontalAlignment.Left);
            scheduledTaskslistView.Columns.Add("Scheduled Time", 350, HorizontalAlignment.Left); // Be cautious with sensitive data
            tasks = storageService.LoadTasks();
            PopulateListViewTasks(tasks);
            // Subscribe to the static event in BackupService
            BackupService.TasksUpdated += RefreshTaskList;
            #endregion
            #region Versions Initialization
            PopulateConfigurations();
            #endregion

        }

        #region Configurations

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

        private void listViewConfigurations_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && configurationsListView.FocusedItem != null && configurationsListView.FocusedItem.Bounds.Contains(e.Location))
            {
                configurationsContextMenuStrip.Show(Cursor.Position);
            }
        }
        private void listViewConfigurations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && configurationsListView.FocusedItem != null && configurationsListView.FocusedItem.Bounds.Contains(e.Location))
            {
                isDoubleClick = true; // Indicate that a double click has occurred
                EditConfiguration(); // Execute double click action
            }
        }


        private void deleteConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configurationsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = configurationsListView.SelectedItems[0];
                Configuration selectedConfiguration = selectedItem.Tag as Configuration;
                if (MessageBox.Show("Are you sure you want to delete this configuration?", "Delete Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<BackupTask> backupTasks = storageService.LoadTasks();
                    BackupTask backupTask = backupTasks.FirstOrDefault(bt => bt.Configuration.Id == selectedConfiguration.Id);
                    if (backupTask != null)
                    {
                        MessageBox.Show("You cannot delete configurations that have associated tasks. Please remove the tasks containing this configuration first.", "Configuration In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        configurationsListView.Items.Remove(selectedItem);
                        configurations.Remove(selectedConfiguration);
                        storageService.SaveConfigurations(configurations);
                        PopulateListView(configurations);
                    }
                }
            }
        }

        private void editConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditConfiguration();
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

        private void EditConfiguration()
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
        #endregion
        #region Tasks
        private void PopulateListViewTasks(List<BackupTask> tasks)
        {
            scheduledTaskslistView.Items.Clear();

            foreach (BackupTask task in tasks)
            {
                ListViewItem item = new ListViewItem(task.BucketName);
                item.SubItems.Add(task.BackupPath);
                item.SubItems.Add(task.ScheduledTime.ToString());
                item.Tag = task;
                scheduledTaskslistView.Items.Add(item);
            }
        }

        private void createTaskButton_Click(object sender, EventArgs e)
        {
            List<Configuration> configurations = storageService.LoadConfigurations();
            if (configurations.Count > 0)
            {
                using (CreateTaskForm createTaskForm = new CreateTaskForm())
                {
                    if (createTaskForm.ShowDialog() == DialogResult.OK)
                    {
                        BackupTask newTask = createTaskForm.Task;
                        newTask.Id = tasks.Count + 1;
                        tasks.Add(newTask);
                        storageService.SaveTasks(tasks);
                        PopulateListViewTasks(tasks);
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
                    tasksContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void deleteTaskToolStripMenuItem_Click(object sender, EventArgs e)
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
                    PopulateListViewTasks(tasks);
                    RescheduleAllTasks();
                }
            }
        }

        private void editTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scheduledTaskslistView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = scheduledTaskslistView.SelectedItems[0];
                BackupTask selectedTask = (BackupTask)selectedItem.Tag;

                using (CreateTaskForm editForm = new CreateTaskForm(selectedTask))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Dispose of the old task's timer to prevent double execution
                        if (selectedTask.Timer != null)
                        {
                            selectedTask.Timer.Dispose();
                            selectedTask.Timer = null; // Clear the old timer
                        }

                        // Update task in the list and reschedule it
                        int index = tasks.IndexOf(selectedTask);
                        if (index != -1)
                        {
                            tasks[index] = editForm.Task;
                        }
                        storageService.SaveTasks(tasks);
                        PopulateListViewTasks(tasks);
                        RescheduleAllTasks(); // This will create a new timer with the updated time
                    }
                }
            }
        }

        private void scheduledTaskslistView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (scheduledTaskslistView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = scheduledTaskslistView.SelectedItems[0];
                BackupTask selectedTask = (BackupTask)selectedItem.Tag;

                using (CreateTaskForm editForm = new CreateTaskForm(selectedTask))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Dispose of the old task's timer to prevent double execution
                        if (selectedTask.Timer != null)
                        {
                            selectedTask.Timer.Dispose();
                            selectedTask.Timer = null; // Clear the old timer
                        }

                        // Update task in the list and reschedule it
                        int index = tasks.IndexOf(selectedTask);
                        if (index != -1)
                        {
                            tasks[index] = editForm.Task;
                        }
                        storageService.SaveTasks(tasks);
                        PopulateListViewTasks(tasks);
                        RescheduleAllTasks(); // This will create a new timer with the updated time
                    }
                }
            }
        }

        private void RescheduleAllTasks()
        {
            BackupService backupService = new BackupService();
            backupService.ScheduleTasks();

            // Refresh the task list in the UI
            tasks = storageService.LoadTasks();
            PopulateListViewTasks(tasks);
        }

        public void RefreshTaskList()
        {
            tasks = storageService.LoadTasks();  // Reload tasks from storage
            PopulateListViewTasks(tasks);        // Repopulate the task list in the UI
        }
        #endregion
        #region Versions

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
            if (e.Button == MouseButtons.Right) // Check if it was a right-click
            {
                // Select the node that was right-clicked
                versionsTreeView.SelectedNode = e.Node;

                if (e.Node.Tag is S3ObjectVersion)
                {
                    // Enable "Download" or other version-related options if it's a version node
                    restoreToolStripMenuItem.Enabled = true;
                    downloadToolStripMenuItem.Enabled = true;
                    deleteVersionToolStripMenuItem.Enabled = true;
                }
                else
                {
                    // Disable the "Download" option or any other version-related options if it's not a version node
                    restoreToolStripMenuItem.Enabled = false;
                    downloadToolStripMenuItem.Enabled = false;
                    deleteVersionToolStripMenuItem.Enabled = false;
                }

                // Show the context menu at the location of the right-click
                versionsContextMenuStrip.Show(versionsTreeView, e.Location);
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

            Dictionary<string, TreeNode> folderNodes = new Dictionary<string, TreeNode>();

            foreach (var obj in allObjects)
            {
                string[] parts = obj.Key.Split('/');
                TreeNode currentNode = null;

                // Iterate through each part of the key and create folders as necessary
                for (int i = 0; i < parts.Length; i++)
                {
                    string part = parts[i];
                    string path = string.Join("/", parts.Take(i + 1));

                    if (i == parts.Length - 1)
                    {
                        // It's a file, so add it under the current node
                        TreeNode fileNode = new TreeNode(part) { Tag = "File" };
                        if (currentNode != null)
                        {
                            currentNode.Nodes.Add(fileNode);
                        }
                        else
                        {
                            versionsTreeView.Nodes.Add(fileNode);
                        }

                        // Add file versions if available
                        var versions = await s3Service.GetObjectVersions(obj.Key);
                        foreach (var version in versions)
                        {
                            TreeNode versionNode = new TreeNode($"{version.VersionId} - {version.LastModified}");
                            versionNode.Tag = version; // Storing the version info for easy access later
                            fileNode.Nodes.Add(versionNode);
                        }
                    }
                    else
                    {
                        // It's a folder, so create the folder node if it doesn't exist
                        if (!folderNodes.ContainsKey(path))
                        {
                            TreeNode folderNode = new TreeNode(part) { Tag = "Folder" };
                            folderNodes[path] = folderNode;

                            if (currentNode != null)
                            {
                                currentNode.Nodes.Add(folderNode);
                            }
                            else
                            {
                                versionsTreeView.Nodes.Add(folderNode);
                            }
                        }

                        currentNode = folderNodes[path];
                    }
                }
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
                    versionsTreeView.Nodes.Clear();
                    GetObjectsFromBucket(s3Service, selectedBucket);
                }
            }
        }

        private async void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = versionsTreeView.SelectedNode;
            if (selectedNode != null && selectedNode.Tag is S3ObjectVersion s3ObjectVersion)
            {
                // Retrieve the full path of the S3 object
                TreeNode fileNode = selectedNode.Parent; // The file node is the parent of the version node
                string s3Key = string.Empty;

                // Traverse back up the tree to get the full path of the object key
                while (fileNode != null)
                {
                    s3Key = fileNode.Text + "/" + s3Key;
                    fileNode = fileNode.Parent;
                }
                s3Key = s3Key.TrimEnd('/'); // Remove the trailing slash if any

                // Find the matching S3 object using the full key
                S3Object s3Object = allObjects.FindLast(s3 => s3.Key == s3Key);
                string versionId = s3ObjectVersion.VersionId;

                // Open a SaveFileDialog to allow the user to select the location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.FileName = Path.GetFileName(s3Key); // Default file name
                    saveFileDialog.Filter = "All files (*.*)|*.*"; // Option to show all files
                    saveFileDialog.Title = "Save File As";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = saveFileDialog.FileName;

                        try
                        {
                            // Download the version to a temporary location first
                            string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

                            await s3Service.DownloadVersion(s3Key, versionId, tempFilePath);

                            // Check if the file has the .enc extension
                            bool isEncrypted = s3Key.EndsWith(".enc");

                            if (isEncrypted)
                            {
                                // Ask for the private key using the PrivateKeyForm
                                using (PrivateKeyForm privateKeyForm = new PrivateKeyForm())
                                {
                                    if (privateKeyForm.ShowDialog() == DialogResult.OK)
                                    {
                                        string privateKey = privateKeyForm.PrivateKey;

                                        // Decrypt the file
                                        bool decrypted = DecryptFile(tempFilePath, selectedFilePath.Replace(".enc", ""), privateKey);

                                        if (decrypted)
                                        {
                                            MessageBox.Show($"Successfully downloaded and decrypted the file to {selectedFilePath.Replace(".enc", "")}.", "Download Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Decryption failed. Please check the private key and try again.", "Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Decryption cancelled.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                // If the file is not encrypted, just move it to the selected location
                                File.Move(tempFilePath, selectedFilePath);
                                MessageBox.Show($"File downloaded successfully to {selectedFilePath}.", "Download Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred during download: {ex.Message}", "Download Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool DecryptFile(string inputFilePath, string outputFilePath, string decryptionKey)
        {
            try
            {
                using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                using (Aes aes = Aes.Create())
                {
                    // Derive key and IV from the decryption key using a salt (e.g., PBKDF2)
                    var key = new Rfc2898DeriveBytes(decryptionKey, Encoding.UTF8.GetBytes("S3EncryptSalt"), 10000);
                    aes.Key = key.GetBytes(32);  // AES-256
                    aes.IV = key.GetBytes(16);   // AES block size is 16 bytes

                    using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                return true; // Decryption successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decryption failed: {ex.Message}");
                return false; // Decryption failed
            }
        }

        private async void deleteVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected node from the TreeView
            TreeNode selectedNode = versionsTreeView.SelectedNode;

            // Check if the selectedNode is valid and contains an S3ObjectVersion in its Tag property
            if (selectedNode != null && selectedNode.Tag is S3ObjectVersion s3ObjectVersion)
            {
                // Rebuild the search key using the directory and the extracted file name
                string searchKey = s3ObjectVersion.Key;  // Ensure S3 uses forward slashes

                Console.WriteLine($"Search Key: '{searchKey}'");

                // Print all keys in the S3 object list for debugging
                Console.WriteLine("Keys in allObjects:");
                foreach (var obj in allObjects)
                {
                    Console.WriteLine($"S3Object: '{obj.Key}'");
                }

                // Search for the S3Object in allObjects using case-insensitive comparison
                S3Object s3Object = allObjects.FindLast(s3 =>
                    string.Equals(s3.Key.Trim(), searchKey.Trim(), StringComparison.OrdinalIgnoreCase)
                );

                // Check if the S3Object is found
                if (s3Object == null)
                {
                    MessageBox.Show("The selected S3 object could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string versionId = s3ObjectVersion.VersionId;

                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to delete version {versionId} of {s3Object.Key}?",
                                                       "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Remove the version from S3
                    await s3Service.DeleteVersion(s3Object.Key, versionId);
                    MessageBox.Show($"Version {versionId} of {s3Object.Key} deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Now remove empty parent nodes (folders) recursively
                    TreeNode parentNode = selectedNode.Parent;

                    if (parentNode != null)
                    {
                        while (parentNode.Nodes.Count > 0 && parentNode.Nodes.Count < 2) // Keep removing parent nodes as long as they have no children
                        {
                            if (parentNode.Parent != null)
                            {
                                TreeNode grandParentNode = parentNode.Parent; // Move up to the grandparent
                                parentNode.Remove();
                                parentNode = grandParentNode; // Continue up the tree
                            }
                            else
                            {
                                parentNode.Nodes.Clear();
                                parentNode.Remove();
                            }

                        }
                        if (parentNode.Nodes.Count < 2)
                        {
                            parentNode.Remove();
                        }
                    }

                    // Remove the node representing the version from the TreeView
                    selectedNode.Remove();
                }
            }
            else
            {
                MessageBox.Show("Please select a valid version to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}