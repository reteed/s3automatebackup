using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3automatebackup.Models
{
    public class BackupTask
    {
        public string Server {  get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int PeriodKey { get; set; }
    }
}