using GamingProject.Data.Context;
using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using GamingProject.Services.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingProject.Services.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly GamingProjectContext _context;
        private readonly IDTOServiceMapper<Device, DeviceDTO> _deviceMapper;

        public DeviceService(GamingProjectContext context,
                             IDTOServiceMapper<Device, DeviceDTO> deviceMapper)
        {
            _context = context;
            _deviceMapper = deviceMapper;
        }

        public async Task<bool> Create(DeviceDTO dto)
        {
            if(await _context.Devices.AnyAsync(x=>x.DeviceName == dto.DeviceName))
            {
                return false;
            }

            var device = new Device()
            {
                DeviceName = dto.DeviceName,
                Type = dto.Type,
                Available = true,
                PlayedTime = new TimeSpan(),
            };

            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<DeviceDTO>> GetAllDevices()
        {
            var devices = await _context.Devices.Where(d=>d.Available==true).ToListAsync();
            var dtos = _deviceMapper.MapFrom(devices);

            return dtos;
        }
    }
}
