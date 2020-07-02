using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClassroomPlatform
{
    public class Program
    {
        public static void InitiateAdmin(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string email = "admin@yahoo.com";
            string password = "P@ssw0rd";
            IdentityUser admin = new IdentityUser
            {
                UserName = email,
                Email = email
            };
            var adminExists = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();
            if (adminExists == null)
            {
                userManager.CreateAsync(admin, password).GetAwaiter().GetResult();
                var role = new IdentityRole("Administrator");
                roleManager.CreateAsync(role).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, "Administrator").GetAwaiter().GetResult();
            }
            if (userManager.IsInRoleAsync(admin, "Administrator").GetAwaiter().GetResult() == false)
            {
                userManager.AddToRoleAsync(admin, "Administrator").GetAwaiter().GetResult();
            }
        }
        public static void Main(string[] args)
        {

            IHost host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var userManager = services.GetService<UserManager<IdentityUser>>();
                InitiateAdmin(userManager, roleManager);

            }

            host.Run();
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
