using Microsoft.EntityFrameworkCore;
using SeedDataModel.Models;

namespace SurfsProject.API.LuxurySeedData.Models
{
    public static class LuxurySeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            /*using (var context = new SurfboardsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SurfboardsContext>>()))
            {
                // Look for any surfboards.
                if (context.Surfboards.Any())
                {
                    return;   // DB has been seeded
                }*/
            modelBuilder.Entity<SurfboardsModel>().HasData(
                   new SurfboardsModel
                   {
                       Id = 25,
                       Name = "The Primium",
                       Length = 6,
                       Width = 21,
                       Thickness = 2.75M,
                       Volume = 38.80M,
                       Type = "Shortboard",
                       Price = 565,
                       Equipment = "",
                      
                   }
 );


        }
    }
}

