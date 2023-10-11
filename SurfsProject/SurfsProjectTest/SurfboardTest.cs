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
    public class SurfboardTests
    {
        [TestMethod]
        public void TestSurfboardLength() 
        {
            // Arrange
            var surfboard = new Surfboard { Length = 6.0m };

            // Act
            var result = surfboard.Length;

            // Assert
            Assert.AreEqual(6.0m, result);
        }

        [TestMethod]
        public void TestSurfboardWidth() 
        {
            // Arrange 
            var surfboard = new Surfboard { Width = 30 };

            // Act
            var result = surfboard.Width;

            // Assert
            Assert.AreEqual(30, result);
        
        }

        [TestMethod]
        public void TestSurfboardThickness() 
        {
            // Arrange
            var surfboard = new Surfboard { Thickness = 2.75m};

            // Act
            var result = surfboard.Thickness;

            // Assert
            Assert.AreEqual(2.75m, result);
        }


        [TestMethod]
        public void TestSurfboardVolume() 
        {
            // Arrange
            var surfboard = new Surfboard { Volume = 30.2m };

            // Act
            var result = surfboard.Volume;

            // Assert
            Assert.AreEqual(30.2m, result);
        }

        [TestMethod]
        public void TestSurfboardType() 
        {
            // Arrange
            var surfboard = new Surfboard { Type = "The Minilog" };

            // Act
            var result = surfboard.Type;

            // Assert
            Assert.AreEqual("The Minilog", result);
        
        }
    }
}
