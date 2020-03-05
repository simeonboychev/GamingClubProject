using GamingProject.Areas.Admin.Models;
using GamingProject.Areas.Moderator.Models;
using GamingProject.Services.DTOs;
using GamingProject.Utilities.Mappers.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Mappers.Registration
{
    public static class MapperRegistration
    {
        public static IServiceCollection AddViewModelCustomMapper(this IServiceCollection services)
        {
            //services.AddSingleton<IViewModelMapper<BarDTO, BarsForCocktailViewModel>, BarsForCocktailViewModelMapper>();
            services.AddTransient<IViewModelMapper<UserDTO, UserViewModel>, UserViewModelMapper>();
            services.AddTransient<IViewModelMapper<DeviceDTO, CreateDeviceViewModel>, DeviceViewModelMapper>();
            services.AddTransient<IViewModelMapper<SessionDTO, CreateSessionViewModel>, CreateSessionViewModelMapper>();
            services.AddTransient<IViewModelMapper<DeviceTypeDTO, CreateDeviceTypeViewModel>, DeviceTypeViewModelMapper>();
            services.AddTransient<IViewModelMapper<DisplaySessionDTO, DisplayHistoryViewModel>, DisplayHistoryViewModelMapper>();


            return services;
        }
    }
}
