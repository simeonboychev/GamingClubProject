using GamingProject.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GamingProject.Services.Services.Contracts
{
    public interface IDeviceTypeService
    {
        Task CreateTypeAsync(string name, double price);
        Task<bool> IsThereType(string name);
        Task<ICollection<DeviceTypeDTO>> GetAllAsync();
    }
}
