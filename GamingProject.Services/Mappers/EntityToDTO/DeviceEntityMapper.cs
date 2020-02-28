using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamingProject.Services.Mappers.EntityToDTO
{
    public class DeviceEntityMapper : IDTOServiceMapper<Device,DeviceDTO>
    {
        public DeviceDTO MapFrom(Device entity)
        {
            //TODO

            return new DeviceDTO
            {
                DeviceName = entity.DeviceName,
                Type = entity.Type,
                PlayedTime = entity.PlayedTime.ToString(),
            };
        }

        public ICollection<DeviceDTO> MapFrom(ICollection<Device> entities)
        {
            return entities.Select(this.MapFrom).ToList();
        }
    }
}
