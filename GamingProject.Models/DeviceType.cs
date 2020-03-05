using System;
using System.Collections.Generic;
using System.Text;

namespace GamingProject.Models
{
    public class DeviceType
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}

