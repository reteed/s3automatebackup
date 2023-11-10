using Newtonsoft.Json;
using s3automatebackup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace s3automatebackup.Services
{
    public class StorageService
    {
        private string configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "s3automatebackup", "configurations.json");
        private string taskFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "s3automatebackup", "tasks.json");

        public List<Configuration> LoadConfigurations()
        {
            if (!File.Exists(configFilePath)) return new List<Configuration>();
            string encryptedJson = File.ReadAllText(configFilePath);
            string json = Unprotect(encryptedJson);
            return JsonConvert.DeserializeObject<List<Configuration>>(json) ?? new List<Configuration>();
        }

        public void SaveConfigurations(List<Configuration> configurations)
        {
            string json = JsonConvert.SerializeObject(configurations, Formatting.Indented);
            string encryptedJson = Protect(json);

            // Ensure the directory exists
            string directoryPath = Path.GetDirectoryName(configFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(configFilePath, encryptedJson);
        }

        public List<BackupTask> LoadTasks()
        {
            if (!File.Exists(taskFilePath)) return new List<BackupTask>();
            string encryptedJson = File.ReadAllText(taskFilePath);
            string json = Unprotect(encryptedJson);
            return JsonConvert.DeserializeObject<List<BackupTask>>(json) ?? new List<BackupTask>();
        }

        public void SaveTasks(List<BackupTask> tasks)
        {
            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            string encryptedJson = Protect(json);
            File.WriteAllText(taskFilePath, encryptedJson);
        }

        private string Protect(string stringData)
        {
            byte[] userData = Encoding.UTF8.GetBytes(stringData);
            byte[] protectedData = ProtectedData.Protect(userData, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedData);
        }

        private string Unprotect(string encryptedData)
        {
            byte[] protectedData = Convert.FromBase64String(encryptedData);
            byte[] userData = ProtectedData.Unprotect(protectedData, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(userData);
        }
    }
}
