using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingProject.Areas.Admin.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Services.Contracts;
using GamingProject.Utilities.Mappers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GamingProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IViewModelMapper<DeviceDTO, CreateDeviceViewModel> _deviceViewModelMapper;

        public DeviceController(IDeviceService deviceService,
            IViewModelMapper<DeviceDTO, CreateDeviceViewModel> deviceViewModelMapper)
        {
            _deviceService = deviceService;
            _deviceViewModelMapper = deviceViewModelMapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDeviceViewModel vm)
        {
            var dto = _deviceViewModelMapper.MapFrom(vm);
            var result = await _deviceService.Create(dto);

            if(result)
            {
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }
    }
}