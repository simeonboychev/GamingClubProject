using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Areas.Moderator.Models
{
    public class CreateSessionViewModel
    {
        public string UserID { get; set; }
        public string DeviceName { get; set; }
        public DateTime StartTime { get; set; }
        public int Minutes { get; set; }
        public List<SelectListItem> AllDevices {get;set;}
        public string SelectedDevice { get; set; }
    }
}
