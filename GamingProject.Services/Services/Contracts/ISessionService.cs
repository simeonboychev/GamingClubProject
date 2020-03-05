using GamingProject.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingProject.Services.Services.Contracts
{
    public interface ISessionService
    {
        Task<ICollection<SessionDTO>> GetActiveSessionsAsync();
        Task<SessionDTO> Create(SessionDTO dto);
        Task EndUserSessionAsync(string id, TimeSpan time);
        Task<ICollection<DisplaySessionDTO>> GetSessionHistoryAsync(string date);
        Task<double> GetSum(string id);
    }
}