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
    }
}