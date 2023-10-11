using SurfsProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SurfsProject.Controllers;
using SurfsProject.Models;
using System.Diagnostics;

namespace SurfsProjectTest
{
    [TestClass]
    public class HomeControllersTest
    {
        private Mock<ILogger<HomeController>> _loggerMock;
        private HomeController _controller;

        [TestInitialize]
        public void Setup() 
        {
            _loggerMock = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_loggerMock.Object);
        }

        [TestMethod]
        public void Index_ReturnsViewResult() 
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Privacy_ReturnsViewResult() 
        {
            // Act
            var result = _controller.Privacy();

            // Assert 
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Error_ReturnsViewResultWithModel() 
        {
            // Act
            var result = _controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ErrorViewModel));
            var model = result.Model as ErrorViewModel;
            Assert.AreEqual(model.RequestId, Activity.Current?.Id ??
                _controller.HttpContext.TraceIdentifier);
        }

       


    }
}