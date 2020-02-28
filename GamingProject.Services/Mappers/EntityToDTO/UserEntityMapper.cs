using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamingProject.Services.Mappers.EntityToDTO
{
    public class UserEntityMapper : IDTOServiceMapper<User, UserDTO>
    {
        public UserDTO MapFrom(User entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                IdentificationNumber = entity.IdentificationNumber,
                IsInSession = entity.IsInSession,
                RegisteredOn = entity.RegisteredOn
            };
        }

        public ICollection<UserDTO> MapFrom(ICollection<User> entities)
        {
            return entities.Select(this.MapFrom).ToList();
        }
    }
}
