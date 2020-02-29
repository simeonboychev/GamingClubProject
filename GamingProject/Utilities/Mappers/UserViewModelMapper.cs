using GamingProject.Areas.Moderator.Models;
using GamingProject.Services.DTOs;
using GamingProject.Utilities.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Mappers
{
    public class UserViewModelMapper : IViewModelMapper<UserDTO, UserViewModel>
    {
        public UserViewModel MapFrom(UserDTO dtoEntity)
        {
            return new UserViewModel()
            {
                Id = dtoEntity.Id,
                FirstName = dtoEntity.FirstName,
                LastName = dtoEntity.LastName,
                PhoneNumber = dtoEntity.PhoneNumber,
                IdentificationNumber = dtoEntity.IdentificationNumber,
                IsInSession = dtoEntity.IsInSession,
                RegisteredOn = dtoEntity.RegisteredOn,
                DeviceName = dtoEntity.CurrentDeviceName,
                DeviceType = dtoEntity.CurrentDeviceType
            };
        }

        public ICollection<UserViewModel> MapFrom(ICollection<UserDTO> dtoEntities)
        {
            return dtoEntities.Select(this.MapFrom).ToList();
        }

        public UserDTO MapFrom(UserViewModel entityVM)
        {
            return new UserDTO()
            {
                Id=entityVM.Id,
                FirstName = entityVM.FirstName,
                LastName = entityVM.LastName,
                PhoneNumber = entityVM.PhoneNumber,
                IdentificationNumber = entityVM.IdentificationNumber,
                IsInSession=entityVM.IsInSession,
                RegisteredOn = entityVM.RegisteredOn
            };
        }

        public ICollection<UserDTO> MapFrom(ICollection<UserViewModel> entitiesVM)
        {
            return entitiesVM.Select(this.MapFrom).ToList();
        }
    }
}
