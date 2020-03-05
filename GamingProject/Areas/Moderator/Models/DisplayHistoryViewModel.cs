using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Areas.Moderator.Models
{
    public class DisplayHistoryViewModel
    {
        public string UserName { get; set; }
        public string DeviceName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
    }
}
