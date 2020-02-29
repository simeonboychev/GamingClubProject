using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingProject.Models
{
    public class Device
    {
        [Key]
        public string DeviceName { get; set; }
        public TimeSpan? PlayedTime { get; set; }
        public bool Available { get; set; }
        public string Type { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
