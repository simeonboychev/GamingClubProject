using GamingProject.Areas.Admin.Models;
using GamingProject.Services.DTOs;
using GamingProject.Utilities.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Mappers
{
    public class DeviceViewModelMapper : IViewModelMapper<DeviceDTO, CreateDeviceViewModel>
    {
        //TODO
        public CreateDeviceViewModel MapFrom(DeviceDTO dtoEntity)
        {
            throw new NotImplementedException();
        }

        public ICollection<CreateDeviceViewModel> MapFrom(ICollection<DeviceDTO> dtoEntities)
        {
            throw new NotImplementedException();
        }

        public DeviceDTO MapFrom(CreateDeviceViewModel entityVM)
        {
            return new DeviceDTO()
            {
                DeviceName = entityVM.DeviceName,
                Type = entityVM.Type,
            };
        }

        public ICollection<DeviceDTO> MapFrom(ICollection<CreateDeviceViewModel> entitiesVM)
        {
            throw new NotImplementedException();
        }
    }
}
