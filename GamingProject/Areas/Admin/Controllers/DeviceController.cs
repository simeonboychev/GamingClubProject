using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingProject.Areas.Admin.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Services.Contracts;
using GamingProject.Utilities.Mappers.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="admin")]
    public class DeviceController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly IViewModelMapper<DeviceDTO, CreateDeviceViewModel> _deviceViewModelMapper;
        private readonly IViewModelMapper<DeviceTypeDTO, CreateDeviceTypeViewModel> _deviceTypeViewModelMapper;
        private readonly IDeviceTypeService _deviceTypeService;

        public DeviceController(IDeviceService deviceService, IViewModelMapper<DeviceDTO, CreateDeviceViewModel> deviceViewModelMapper, IViewModelMapper<DeviceTypeDTO, CreateDeviceTypeViewModel> deviceTypeViewModelMapper, IDeviceTypeService deviceTypeService)
        {
            _deviceService = deviceService;
            _deviceViewModelMapper = deviceViewModelMapper;
            _deviceTypeViewModelMapper = deviceTypeViewModelMapper;
            _deviceTypeService = deviceTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var devicetypes = await _deviceTypeService.GetAllAsync();
            var vm = _deviceTypeViewModelMapper.MapFrom(devicetypes);
            var newvm = new CreateDeviceViewModel
            {
                DeviceTypes = vm
            };
            return View(newvm);
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
        public IActionResult CreateType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateType(string name,string price)
        {
            if(await _deviceTypeService.IsThereType(name))
            {
                return new JsonResult("faketype");
            }
            price = price.Replace('.', ',');
            await _deviceTypeService.CreateTypeAsync(name,Double.Parse(price));
            return new JsonResult("");
        }
    }
}