using Microsoft.EntityFrameworkCore;
using SeedDataAPI.Models;
using SurfsProject.API.SeedDataAPI.Models;

namespace API.Models
{
    public partial class SurfboardsContext : DbContext
    {


        public SurfboardsContext(DbContextOptions<SurfboardsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurfboardsAPI>();
                
            modelBuilder.Seed();
        }



        public DbSet<SurfboardsAPI> Surfboards { get; set; } = default!;
        


        //public DbSet<SurfboardsAPI.Models.SurfboardsAPI> Identity { get; set; } = default!;


    }
}

