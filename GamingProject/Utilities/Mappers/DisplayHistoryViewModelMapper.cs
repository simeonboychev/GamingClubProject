using GamingProject.Areas.Moderator.Models;
using GamingProject.Services.DTOs;
using GamingProject.Utilities.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Mappers
{
    public class DisplayHistoryViewModelMapper : IViewModelMapper<DisplaySessionDTO, DisplayHistoryViewModel>
    {
        public DisplayHistoryViewModel MapFrom(DisplaySessionDTO dtoEntity)
        {
            return new DisplayHistoryViewModel()
            {
                UserName=dtoEntity.UserName,
                DeviceName=dtoEntity.DeviceName,
                StartTime=dtoEntity.StartTime,
                Duration=dtoEntity.Duration,
                Price=dtoEntity.Price,
            };
        }

        public ICollection<DisplayHistoryViewModel> MapFrom(ICollection<DisplaySessionDTO> dtoEntities)
        {
            return dtoEntities.Select(this.MapFrom).ToList();
        }

        public DisplaySessionDTO MapFrom(DisplayHistoryViewModel entityVM)
        {
            throw new NotImplementedException();
        }

        public ICollection<DisplaySessionDTO> MapFrom(ICollection<DisplayHistoryViewModel> entitiesVM)
        {
            throw new NotImplementedException();
        }
    }
}
