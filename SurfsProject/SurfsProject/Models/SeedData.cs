using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurfsProject.Data;
using System;
using System.Linq;

namespace  SurfsProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SurfsProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SurfsProjectContext>>()))
            {
                // Look for any surfboards.
                if (context.Surfboard.Any())
                {
                    return;   // DB has been seeded
                }

               
            }
        }
    }
}