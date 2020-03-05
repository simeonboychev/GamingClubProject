using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamingProject.Services.Mappers.EntityToDTO
{
    public class DeviceTypeEntityMapper : IDTOServiceMapper<DeviceType, DeviceTypeDTO>
    {
        public DeviceTypeDTO MapFrom(DeviceType entity)
        {
            //TODO

            return new DeviceTypeDTO
            {
                Id = entity.Id,
                Type = entity.Type,
                Price = entity.Price
            };
        }

        public ICollection<DeviceTypeDTO> MapFrom(ICollection<DeviceType> entities)
        {
            return entities.Select(this.MapFrom).ToList();
        }
    }
}
