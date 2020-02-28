using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Areas.Moderator.Models
{
    public class HomePageViewModel
    {
        public ICollection<UserViewModel> UserViews { get; set; }
        public UserViewModel UserViewModel { get; set; }
    }
}
