using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingProject.Areas.Moderator.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Services.Contracts;
using GamingProject.Utilities.Mappers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamingProject.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class SessionController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly ISessionService _sessionService;
        private readonly IViewModelMapper<SessionDTO, CreateSessionViewModel> _createSessionViewModelMapper;

        public SessionController(IDeviceService deviceService,
                                 ISessionService sessionService,
                                 IViewModelMapper<SessionDTO, CreateSessionViewModel> createSessionViewModelMapper)
        {
            _deviceService = deviceService;
            _sessionService = sessionService;
            _createSessionViewModelMapper = createSessionViewModelMapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Asd()
        {
            return View();
        }
        public async Task<IActionResult> CreateSession(string id)
        {
            var devices = await _deviceService.GetAllDevices();
            var deviceSelectList = devices.Select(d => new SelectListItem { Text=d.Type,Value=d.DeviceName}).OrderBy(x=>x.Text).ThenBy(x=>x.Value.Length).ThenBy(x=>x.Value).ToList();
            
            var vm = new CreateSessionViewModel()
            {
                UserID = id,
                AllDevices = deviceSelectList,
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSession(CreateSessionViewModel vm)
        {
            var dto = _createSessionViewModelMapper.MapFrom(vm);
            await _sessionService.Create(dto);

            return Redirect("~/Moderator/Member/OnlineUsers");
        }
    }
}