using GamingProject.Areas.Admin.Models;
using GamingProject.Services.DTOs;
using GamingProject.Utilities.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Mappers
{
    public class DeviceTypeViewModelMapper : IViewModelMapper<DeviceTypeDTO, CreateDeviceTypeViewModel>
    {
        public CreateDeviceTypeViewModel MapFrom(DeviceTypeDTO dtoEntity)
        {
            return new CreateDeviceTypeViewModel
            {
                Id = dtoEntity.Id,
                Type = dtoEntity.Type
            };
        }

        public ICollection<CreateDeviceTypeViewModel> MapFrom(ICollection<DeviceTypeDTO> dtoEntities)
        {
            return dtoEntities.Select(this.MapFrom).ToList();
        }

        public DeviceTypeDTO MapFrom(CreateDeviceTypeViewModel entityVM)
        {
            throw new NotImplementedException();
        }

        public ICollection<DeviceTypeDTO> MapFrom(ICollection<CreateDeviceTypeViewModel> entitiesVM)
        {
            throw new NotImplementedException();
        }
    }
}
