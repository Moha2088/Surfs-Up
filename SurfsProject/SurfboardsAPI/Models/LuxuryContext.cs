using Microsoft.EntityFrameworkCore;
using LuxurySeedData.Models;
using SurfsProject.API.SeedDataModel.Models;

namespace LuxuryAPI.Models
{
    public partial class LuxuryContext : DbContext
    {


        public LuxuryContext(DbContextOptions<LuxuryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LuxurySurfboardsModel>();

            modelBuilder.Seed();
        }

        public DbSet<LuxurySurfboardsModel> LuxurySurfboards { get; internal set; } = default!; 
    }
}
