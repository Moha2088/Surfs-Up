using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurfsProject.Models;

namespace SurfsProject.Data
{
    public partial class SurfsProjectContext : IdentityDbContext<IdentityUser>
    {
        public SurfsProjectContext (DbContextOptions<SurfsProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SurfsProject.Models.Surfboard> Surfboard { get; set; } = default!;
    
    }
}
