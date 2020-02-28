using GamingProject.Services.Services;
using GamingProject.Services.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Extensions
{
    public static class BusinessLogicRegistration
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IMemberService,MemberService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<ISessionService, SessionService>();

            return services;
        }
    }
}
