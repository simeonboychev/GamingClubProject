using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GamingProject.Services.DTOs
{
    public class SessionDTO
    {
        public string UserID { get; set; }
        public string DeviceID { get; set; }
        public DateTime StartTime { get; set; }
    }
}
