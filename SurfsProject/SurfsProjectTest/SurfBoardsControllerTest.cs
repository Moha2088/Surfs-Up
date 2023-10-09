using SurfsProject.Controllers;
using SurfsProject.Models;
using SurfsProject.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SurfsProject 
{
    [TestClass]
    public class SurfBoardsControllerTest 
    {
        private Mock<SurfsProjectContext> _contextMock;
        private SurfboardsController _controller;
        
        [TestMethod]
        public void Setup() 
        {
            // Arrange
            _contextMock = new Mock<SurfsProjectContext>();
            _controller = new SurfboardsController(_contextMock.Object);
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFound_WhenIdIsNull() 
        {
            // Act
            var result = await _controller.Delete(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFound_WhenContextIsNull() 
        {
            // Arrange
            _contextMock.Setup(c => c.Surfboard).Returns((DbSet<Surfboard>)null);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFound_WhenSurfboardDoesNotExist() 
        {
            // Arrange
            var surfboard = new Surfboard { Id = 1, Name = "Test", Price = 100 };
            _contextMock.Setup(c => c.Surfboard.FindAsync(1)).ReturnsAsync(surfboard);
            _contextMock.Setup(c => c.Surfboard.FindAsync(2)).ReturnsAsync((Surfboard)null);

            // Act
            var result = await _controller.Delete(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        
        }

        [TestMethod]
        public async Task Delete_ReturnsViewResultWithModel_WhenSurfboardExists() 
        {
            // Arrange
            var surfboard = new Surfboard { Id = 1, Name = "Test", Price = 100 };
            _contextMock.Setup(c => c.Surfboard.FindAsync(1)).ReturnsAsync(surfboard);

            // Act
            var result = await _controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(Surfboard));
            var model = result.Model as Surfboard;
            Assert.AreEqual(model.Id, surfboard.Name);
            Assert.AreEqual(model.Name, surfboard.Name);
            Assert.AreEqual(model.Price, surfboard.Price);
            
        }

        
    
    }

}
