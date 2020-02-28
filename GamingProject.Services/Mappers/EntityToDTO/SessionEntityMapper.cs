using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamingProject.Services.Mappers.EntityToDTO
{
    public class SessionEntityMapper : IDTOServiceMapper<Session, SessionDTO>
    {
        public SessionDTO MapFrom(Session entity)
        {
            return new SessionDTO
            {
                DeviceID = entity.DeviceID,
                UserID = entity.UserID,
                StartTime = entity.SessionStart
            };
        }

        public ICollection<SessionDTO> MapFrom(ICollection<Session> entities)
        {
            return entities.Select(this.MapFrom).ToList();
        }
    }
}
