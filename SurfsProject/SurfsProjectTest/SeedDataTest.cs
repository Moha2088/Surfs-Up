using System;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Text;
using SurfsProject.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SurfsProject.Data;
using Microsoft.EntityFrameworkCore;
namespace SurfsProjectTest
{
    [TestClass]
    public class SeedDataTest
    {
        //[TestMethod]
        //public void TestSeedData() 
        //{
        //    // Arrange
        //    var serviceProvider = new ServiceCollection()
        //        .AddDbContext<SurfsProjectContext>((options, DbContextOptionsBuilder) =>
        //            options.UseInMemoryDatabase(databaseName: "TestDatabase"))
        //        .BuildServiceProvider();

        //    // Act
        //    SeedData.Initialize(serviceProvider);

        //    // Assert
        //    using (var context = new SurfsProjectContext
        //        (serviceProvider.GetRequiredService<DbContextOptions<SurfsProjectContext>>()))
        //    {
        //        Assert.AreEqual(4, context.Surfboard.Count());
        //    }
        //}
    }
}
