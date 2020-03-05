using GamingProject.Data.Context;
using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using GamingProject.Services.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamingProject.Services.Services
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly GamingProjectContext _context;
        private readonly IDTOServiceMapper<DeviceType, DeviceTypeDTO> _mapper;

        public DeviceTypeService(GamingProjectContext context, IDTOServiceMapper<DeviceType, DeviceTypeDTO> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateTypeAsync(string name,double price)
        {
            var devicetype = new DeviceType
            {
                Id = Guid.NewGuid().ToString(),
                Type = name,
                Price = price
                
            };
            await _context.DeviceTypes.AddAsync(devicetype);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<DeviceTypeDTO>> GetAllAsync()
        {
            var devices = await _context.DeviceTypes.ToListAsync();
            return _mapper.MapFrom(devices);
        }

        public async Task<bool> IsThereType(string name)
        {
            return await _context.DeviceTypes.AnyAsync(x => x.Type == name);
        }
    }
}
