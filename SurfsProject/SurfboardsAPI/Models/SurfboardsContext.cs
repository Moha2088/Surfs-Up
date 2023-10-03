using Microsoft.EntityFrameworkCore;
using SeedDataModel.Models;
using SurfsProject.API.SeedDataModel.Models;



namespace API.Models
{
    public partial class SurfboardsContext : DbContext
    {


        public SurfboardsContext(DbContextOptions<SurfboardsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurfboardsModel>();

            modelBuilder.Seed();
        }
        public DbSet<SurfboardsModel> Surfboards { get; set; } = default!;
    }
    /*public partial class Rentingcontext : DbContext
    {
            public RentingContext(DbContextOptions<RentingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Renting>();

            modelBuilder.();
        }
        public DbSet<SurfboardsModel> Surfboards { get; set; } = default!;

    }

        
        


        //public DbSet<SurfboardsModel.Models.SurfboardsModel> Identity { get; set; } = default!;*/


    
}

