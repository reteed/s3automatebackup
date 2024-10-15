using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3automatebackup.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string SuccessEmail { get; set; }
        public string FailureEmail { get; set; }
        public string SmtpHost { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }
    }
}