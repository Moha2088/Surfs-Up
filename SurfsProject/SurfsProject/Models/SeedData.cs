﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
                //Seed Surfboards
                if (!context.Surfboard.Any())
                {

                    context.Surfboard.AddRange(
                       new Surfboard
                       {
                           Name = "The Minilog",
                           Length = 6,
                           Width = 21,
                           Thickness = 2.75M,
                           Volume = 38.80M,
                           Type = "Shortboard",
                           Price = 565,
                           Equipment = "",
                       },

                       new Surfboard
                       {
                           Name = "The Wide Glider",
                           Length = 7.1M,
                           Width = 21.75M,
                           Thickness = 2.75M,
                           Volume = 44.16M,
                           Type = "Funboard",
                           Price = 685,
                           Equipment = "",
                       },

                       new Surfboard
                       {
                           Name = "The Golden Ratio",
                           Length = 6.3M,
                           Width = 21.85M,
                           Thickness = 2.9M,
                           Volume = 43.22M,
                           Type = "Shortboard",
                           Price = 695,
                           Equipment = "",
                       },

                       new Surfboard
                       {
                           Name = "Mahi Mahi",
                           Length = 6.3M,
                           Width = 20.75M,
                           Thickness = 2.3M,
                           Volume = 29.39M,
                           Type = "Fish",
                           Price = 645,
                           Equipment = "",
                       },

                        new Surfboard
                        {
                            Name = "The Emerald Glider",
                            Length = 9.2M,
                            Width = 22.8M,
                            Thickness = 2.8M,
                            Volume = 65.4M,
                            Type = "Longboard",
                            Price = 895,
                            Equipment = "",
                        },

                         new Surfboard
                         {
                             Name = "The Bomb",
                             Length = 5.5M,
                             Width = 21,
                             Thickness = 2.5M,
                             Volume = 33.7M,
                             Type = "Shortboard",
                             Price = 645,
                             Equipment = "",
                         },

                          new Surfboard
                          {
                              Name = "Walden Magic",
                              Length = 9.6M,
                              Width = 19.4M,
                              Thickness = 3,
                              Volume = 80,
                              Type = "Longboard",
                              Price = 1025,
                              Equipment = "",
                          },

                           new Surfboard
                           {
                               Name = "Naish One",
                               Length = 12.6M,
                               Width = 30M,
                               Thickness = 6,
                               Volume = 301,
                               Type = "SUP",
                               Price = 854,
                               Equipment = "Paddle",
                           },

                            new Surfboard
                            {
                                Name = "Six Tourer",
                                Length = 11.6M,
                                Width = 32,
                                Thickness = 6,
                                Volume = 270,
                                Type = "SUP",
                                Price = 611,
                                Equipment = "Fin, Paddle, Pump, Leash",
                            },

                             new Surfboard
                             {
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

                //Seed Admin Role
                IdentityRole admin = SeedAdmininstratorRole(context);

                SeedAdmininistratorUser(context, admin);


                context.SaveChanges();

            }
        }

        private static IdentityRole SeedAdmininstratorRole(IdentityDbContext<IdentityUser> context)
        {
            IdentityRole admin = context.Roles.FirstOrDefault(x => x.Name == "Administrator");
            if (admin == null)
            {
                admin = new IdentityRole("Administrator");
                context.Roles.Add(admin);
            }
            return (admin);
        }

        private static void SeedAdmininistratorUser(IdentityDbContext<IdentityUser> context, IdentityRole admin)
        {
            IdentityUserRole<string> adminRole = context.UserRoles.FirstOrDefault(x => x.RoleId == admin.Id);
            if(adminRole == null)
            {
                IdentityUser adminUser = SeedUser(context, "admin@surfs.up", "Test Password");
                adminRole = new IdentityUserRole<string> { RoleId = admin.Id, UserId = adminUser.Id };
                context.Add(adminRole);
            }
        }

        private static IdentityUser SeedUser(IdentityDbContext<IdentityUser> context, string email, string password)
        {
            IdentityUser user = context.Users.FirstOrDefault(x => x.Email == email);
            if(user == null)
            {
                user = new IdentityUser
                {
                    Email = email,
                    UserName = email,
                    NormalizedEmail = email.Normalize(),
                    NormalizedUserName = email.Normalize(),
                    EmailConfirmed = true
                };
                PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
                user.PasswordHash = hasher.HashPassword(user, password);
                context.Add(user);
            }
            return user;
        }
    }
}