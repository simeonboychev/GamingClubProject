using GamingProject.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingProject.Services.Services.Contracts
{
    public interface IDeviceService
    {
        Task<bool> Create(DeviceDTO dto);
        Task<ICollection<DeviceDTO>> GetAllDevices();
    }
}