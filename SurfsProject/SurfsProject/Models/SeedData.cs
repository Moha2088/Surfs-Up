﻿using Microsoft.EntityFrameworkCore;
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
                // Look for any movies.
                if (context.Surfboard.Any())
                {
                    return;   // DB has been seeded
                }

                context.Surfboard.AddRange(
                    new Surfboard
                    {
                        Name = "The Minilog",
                        Length = 6.0,
                        Width = 21.0,
                        Thickness = 2.75,
                        Volume = 38.8,
                        Type = "Shortboard",
                        Price = 565,
                        Equipment = "None"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}