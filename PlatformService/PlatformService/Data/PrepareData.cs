using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepareData
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (! context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data");
                
                context.Platforms.AddRange(
                    new Platform{ Name = ".Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform{ Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform{ Name = "K8S", Publisher = "CNCF", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data already exist");
            }
        }
    }
}