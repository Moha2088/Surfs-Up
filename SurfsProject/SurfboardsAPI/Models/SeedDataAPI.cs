
using Microsoft.EntityFrameworkCore;
using SeedDataAPI.Models;

namespace SurfsProject.API.SeedDataAPI.Models
{
    public static class SeedDataAPI
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
            modelBuilder.Entity<SurfboardsAPI>().HasData(
                   new SurfboardsAPI
                   {
                       Id = 1, 
                       Name = "The Minilog", 
                       Length = 6, Width = 21, 
                       Thickness = 2.75M,
                       Volume = 38.80M,
                       Type = "Shortboard",
                       Price = 565,
                       Equipment = "",
                   },

                   new SurfboardsAPI
                   {
                       Id=2,
                       Name = "The Wide Glider",
                       Length = 7.1M,
                       Width = 21.75M,
                       Thickness = 2.75M,
                       Volume = 44.16M,
                       Type = "Funboard",
                       Price = 685,
                       Equipment = "",
                   },

                   new SurfboardsAPI
                   {
                       Id = 3,
                       Name = "The Golden Ratio",
                       Length = 6.3M,
                       Width = 21.85M,
                       Thickness = 2.9M,
                       Volume = 43.22M,
                       Type = "Shortboard",
                       Price = 695,
                       Equipment = "",
                   },

                   new SurfboardsAPI
                   {
                       Id = 4,
                       Name = "Mahi Mahi",
                       Length = 6.3M,
                       Width = 20.75M,
                       Thickness = 2.3M,
                       Volume = 29.39M,
                       Type = "Fish",
                       Price = 645,
                       Equipment = "",
                   },

                    new SurfboardsAPI
                    {
                        Id = 5,
                        Name = "The Emerald Glider",
                        Length = 9.2M,
                        Width = 22.8M,
                        Thickness = 2.8M,
                        Volume = 65.4M,
                        Type = "Longboard",
                        Price = 895,
                        Equipment = "",
                    },

                     new SurfboardsAPI
                     {
                         Id = 6,
                         Name = "The Bomb",
                         Length = 5.5M,
                         Width = 21,
                         Thickness = 2.5M,
                         Volume = 33.7M,
                         Type = "Shortboard",
                         Price = 645,
                         Equipment = "",
                     },

                      new SurfboardsAPI
                      {
                          Id = 7,
                          Name = "Walden Magic",
                          Length = 9.6M,
                          Width = 19.4M,
                          Thickness = 3,
                          Volume = 80,
                          Type = "Longboard",
                          Price = 1025,
                          Equipment = "",
                      },

                       new SurfboardsAPI
                       {
                           Id = 8,
                           Name = "Naish One",
                           Length = 12.6M,
                           Width = 30M,
                           Thickness = 6,
                           Volume = 301,
                           Type = "SUP",
                           Price = 854,
                           Equipment = "Paddle",
                       },

                        new SurfboardsAPI
                        {
                            Id = 9,
                            Name = "Six Tourer",
                            Length = 11.6M,
                            Width = 32,
                            Thickness = 6,
                            Volume = 270,
                            Type = "SUP",
                            Price = 611,
                            Equipment = "Fin, Paddle, Pump, Leash",
                        },

                         new SurfboardsAPI
                         {
                             Id = 10,
                             Name = "Naish Maliko",
                             Length = 14,
                             Width = 25,
                             Thickness = 6,
                             Volume = 330,
                             Type = "SUP",
                             Price = 1304,
                             Equipment = "Fin, Paddle, Pump, Leash",
                         }


               );
                

        }
    }
}

