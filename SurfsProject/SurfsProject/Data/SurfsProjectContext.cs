using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurfsProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SurfsProject.Data
{
    public class SurfsProjectContext : IdentityDbContext
    {
        public SurfsProjectContext (DbContextOptions<SurfsProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SurfsProject.Models.Surfboard> Surfboard { get; set; } = default!;
    }
}
