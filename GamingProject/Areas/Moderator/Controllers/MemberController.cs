using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingProject.Areas.Moderator.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Services.Contracts;
using GamingProject.Utilities.Mappers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GamingProject.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IDeviceService _deviceService;
        private readonly ISessionService _sessionService;
        private readonly IViewModelMapper<UserDTO, UserViewModel> _userViewModelMapper;

        public MemberController(IMemberService memberService, 
            IDeviceService deviceService,
            ISessionService sessionService, 
            IViewModelMapper<UserDTO, UserViewModel> userViewModelMapper)
        {
            _memberService = memberService;
            _deviceService = deviceService;
            _sessionService = sessionService;
            _userViewModelMapper = userViewModelMapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel viewModel)
        {
            if (await _memberService.ContainPhoneAsync(viewModel.PhoneNumber))
            {
                return new JsonResult("fakephone");
            }
            var dto = _userViewModelMapper.MapFrom(viewModel);
            await _memberService.CreateUser(dto);

            return Redirect("~/Moderator/Member/OnlineUsers");
        }
        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var dtos = await _memberService.AllUsers();
            var viewModels = _userViewModelMapper.MapFrom(dtos);
            var viewModel = new HomePageViewModel()
            {
                UserViews = viewModels,
                UserViewModel = new UserViewModel(),
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> OnlineUsers()
        {
            var sessions = await _sessionService.GetActiveSessionsAsync();
            
            var dtos = await _memberService.OnlineUsers();
            var viewModels = _userViewModelMapper.MapFrom(dtos);
            foreach(var user in viewModels)
            {
                foreach(var session in sessions )
                {
                    if(user.Id==session.UserID)
                    {
                        user.CurrentPlaying = DateTime.Now.Subtract(session.StartTime);
                    }
                }
            }
            return View(viewModels);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var dto = await _memberService.GetUserAsync(id);
            var viewModel = _userViewModelMapper.MapFrom(dto);

            return View(viewModel);
        }

        public async Task EndSession(string id, TimeSpan time)
        {
            await _sessionService.EndUserSessionAsync(id,time);
            
        }

        public async Task<string> CalculateSum(string id)
        {
            var sum = await _sessionService.GetSum(id);

            return String.Format("{0:0.00}", sum);
        }
    }
}