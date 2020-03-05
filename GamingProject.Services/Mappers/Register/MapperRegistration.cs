using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using GamingProject.Services.Mappers.EntityToDTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamingProject.Services.Mappers.Register
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddCustomDTOMappers(this IServiceCollection services)
        {
            services.AddScoped<IDTOServiceMapper<User, UserDTO>, UserEntityMapper>();
            services.AddScoped<IDTOServiceMapper<Device, DeviceDTO>, DeviceEntityMapper>();
            services.AddScoped<IDTOServiceMapper<Session, SessionDTO>, SessionEntityMapper>();
            services.AddScoped<IDTOServiceMapper<Session, DisplaySessionDTO>, DisplaySessionEntityMapper>();
            services.AddScoped<IDTOServiceMapper<DeviceType, DeviceTypeDTO>, DeviceTypeEntityMapper>();
            
            return services;
        }
    }
}
