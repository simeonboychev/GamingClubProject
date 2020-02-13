using GamingProject.Data.Context;
using GamingProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GamingProjectContext>();
                context.Database.EnsureCreated();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();


                Task.Run(async () =>
                {
                    var adminName = "admin";

                    var adminExists = await roleManager.RoleExistsAsync(adminName);

                    if (!adminExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName
                        });
                    }

                    var moderatorName = "moderator";

                    var moderatorExists = await roleManager.RoleExistsAsync(moderatorName);

                    if (!moderatorExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = moderatorName
                        });
                    }

                    var userName = "user";

                    var userExists = await roleManager.RoleExistsAsync(userName);

                    if (!userExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = userName
                        });
                    }

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = "admin",
                            Email = "admin@admin.com",
                        };

                        await userManager.CreateAsync(adminUser, "admin12");
                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }
                })
                .GetAwaiter()
                .GetResult();
            }
        }
    }
}
