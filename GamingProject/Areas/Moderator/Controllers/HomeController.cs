using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingProject.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles ="moderator")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("~/Moderator/Member/OnlineUsers");
        }
    }
}