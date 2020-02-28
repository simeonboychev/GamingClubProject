using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace GamingProject.Models
{
    public class Session
    {
        public DateTime SessionStart { get; set; }

        public bool IsDeleted { get; set; }

        public string UserID { get; set; }
        public User User { get; set; }

        public string DeviceID { get; set; }
        public Device Device { get; set; }
    }
}
