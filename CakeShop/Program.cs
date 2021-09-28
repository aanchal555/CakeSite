using CakeShop.Persistence;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CakeShop
{
    public class Program
    {
        private static CakeShopDbContext context;
        private static UserManager<IdentityUser> usermanger;
        private static RoleManager<IdentityRole> roleManager;
        private static IConfiguration env;

        public static async Task Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                context = scope.ServiceProvider.GetRequiredService<CakeShopDbContext>();
                usermanger = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                env = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                
                await DbInitializer.SeedDatabaseAsync(context, usermanger, roleManager, env);
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
