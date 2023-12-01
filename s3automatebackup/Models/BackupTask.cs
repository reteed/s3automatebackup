using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3automatebackup.Models
{
    public class BackupTask
    {
        public int Id { get; set; } 
        public required Configuration Configuration { get; set; }
        public required string BucketName { get; set; }
        public required string BackupFolder { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int PeriodKey { get; set; }
        public System.Threading.Timer? Timer { get; set; }
    }
}