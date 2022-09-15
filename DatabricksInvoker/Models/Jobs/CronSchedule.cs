using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs
{
    public class CronSchedule
    {
        public CronSchedule(string quartzCronExpression, string timezoneId, string pauseStatus = "UNPAUSED")
        {
            QuartzCronExpression = quartzCronExpression;
            TimezoneId = timezoneId;
            PauseStatus = pauseStatus;
        }

        public string QuartzCronExpression { get; set; }

        public string TimezoneId { get; set; }

        public string PauseStatus { get; set; }
    }
}
