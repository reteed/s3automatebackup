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
        public Configuration Configuration { get; set; }
        public string BucketName { get; set; }
        public string BackupPath { get; set; }
        public DateTime ScheduledTime { get; set; }
        public int PeriodKey { get; set; }
        public bool DeletePath { get; set; }
        public bool Hierarchy { get; set; }
        public System.Threading.Timer Timer { get; set; }
        public bool RemoveOldFiles { get; set; }
        public int OldFilesDays { get; set; }
    }
}