using System;
using System.Collections.Generic;
using System.Text;

namespace GamingProject.Services.DTOs
{
    public class DisplaySessionDTO
    {
        public string UserName { get; set; }
        public string DeviceName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
    }
}
