using GamingProject.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingProject.Services.Services.Contracts
{
    public interface IMemberService
    {
        Task<ICollection<UserDTO>> AllUsers();
        Task<UserDTO> CreateUser(UserDTO user);
        Task<UserDTO> GetUserAsync(string FirstName);
        Task<ICollection<UserDTO>> OnlineUsers();
    }
}