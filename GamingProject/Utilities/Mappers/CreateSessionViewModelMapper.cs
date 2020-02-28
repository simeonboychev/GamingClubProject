using GamingProject.Areas.Moderator.Models;
using GamingProject.Services.DTOs;
using GamingProject.Utilities.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Mappers
{
    public class CreateSessionViewModelMapper : IViewModelMapper<SessionDTO, CreateSessionViewModel>
    {
        public CreateSessionViewModel MapFrom(SessionDTO dtoEntity)
        {
            return new CreateSessionViewModel()
            {
                DeviceName=dtoEntity.DeviceID,
                StartTime=dtoEntity.StartTime,
                UserID=dtoEntity.UserID
            };
        }

        public ICollection<CreateSessionViewModel> MapFrom(ICollection<SessionDTO> dtoEntities)
        {
            return dtoEntities.Select(this.MapFrom).ToList();
        }

        public SessionDTO MapFrom(CreateSessionViewModel entityVM)
        {
            //TODO
            return new SessionDTO()
            {
                DeviceID = entityVM.SelectedDevice,
                StartTime = entityVM.StartTime,
                UserID = entityVM.UserID
            };
        }

        public ICollection<SessionDTO> MapFrom(ICollection<CreateSessionViewModel> entitiesVM)
        {
            return entitiesVM.Select(this.MapFrom).ToList();
        }
    }
}
