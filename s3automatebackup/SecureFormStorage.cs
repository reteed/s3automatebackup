using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace s3automatebackup
{
    public class SecureFormStorage
    {
        private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "yourApp", "data.txt");

        private byte[] Protect(string stringData)
        {
            byte[] userData = Encoding.UTF8.GetBytes(stringData);
            return ProtectedData.Protect(userData, null, DataProtectionScope.CurrentUser);
        }

        private string Unprotect(byte[] encryptedData)
        {
            byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedData);
        }

        public void SaveFormFields(string data)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Ensure directory exists
            byte[] encryptedData = Protect(data);
            File.WriteAllBytes(filePath, encryptedData);
        }

        public string LoadFormFields()
        {
            if (File.Exists(filePath))
            {
                byte[] encryptedData = File.ReadAllBytes(filePath);
                return Unprotect(encryptedData);
            }
            return null;
        }
    }
}