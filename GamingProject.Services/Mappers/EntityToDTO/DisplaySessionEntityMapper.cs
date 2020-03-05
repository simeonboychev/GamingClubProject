using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamingProject.Services.Mappers.EntityToDTO
{
    public class DisplaySessionEntityMapper : IDTOServiceMapper<Session, DisplaySessionDTO>
    {
        public DisplaySessionDTO MapFrom(Session entity)
        {
            return new DisplaySessionDTO()
            {
                DeviceName = entity.Device.DeviceName,
                Duration=entity.Duration,
                StartTime=entity.SessionStart,
                Price=entity.Price,
                UserName=entity.User.FirstName + " " + entity.User.LastName,
            };
        }

        public ICollection<DisplaySessionDTO> MapFrom(ICollection<Session> entities)
        {
            throw new NotImplementedException();
        }
    }
}
