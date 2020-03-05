using GamingProject.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Areas.Admin.Models
{
    public class AllDeviceTypesViewModel
    {
        public ICollection<DeviceTypeDTO> Devices { get; set; }
    }
}
