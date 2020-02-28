using GamingProject.Data.Context;
using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using GamingProject.Services.Mappers.EntityToDTO;
using GamingProject.Services.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingProject.Services.Services
{
    public class MemberService : IMemberService
    {
        private readonly GamingProjectContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IDTOServiceMapper<User, UserDTO> _userMapper;

        public MemberService(GamingProjectContext context,
                             UserManager<User> userManager,
                             IDTOServiceMapper<User, UserDTO> userMapper)
        {
            _context = context;
            _userManager = userManager;
            _userMapper = userMapper;
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                IdentificationNumber = user.IdentificationNumber,
                RegisteredOn = DateTime.Now,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            await _userManager.AddToRoleAsync(newUser, "user");
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<UserDTO> GetUserAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            var userDTO = _userMapper.MapFrom(user);

            return userDTO;
        }

        //var pcMinutes = await _context.Sessions.Where(x => x.UserID == "iwakaid" && x.Device.Type == "PC").SumAsync(x => x.SessionMinutes);
        public async Task<ICollection<UserDTO>> AllUsers()
        {
            var usersOfRole = await _userManager.GetUsersInRoleAsync("user");

            //var users = await _context.Users.Where(u=>u.).ToListAsync();
            var usersDTO = _userMapper.MapFrom(usersOfRole);



            return usersDTO;
        }
        public async Task<ICollection<UserDTO>> OnlineUsers()
        {
            var sessions = _context.Sessions.Where(s => s.IsDeleted == false);
            var users = await sessions.Select(s => s.User).ToListAsync();
            //var users = (await _userManager.GetUsersInRoleAsync("user")).Where().ToList();
            var usersDTO = _userMapper.MapFrom(users);

            return usersDTO;
        }
    }
}
