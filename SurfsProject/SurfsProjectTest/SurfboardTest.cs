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
        public void TestSurfboardId() 
        {
            // Act
            var surfboard = new Surfboard { Id = 10 };

            // Arrange
            var result = surfboard.Id;

            // Assert
            Assert.AreEqual(10, result);
        }

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
            var surfboard = new Surfboard { Type = "Funboard" };

            // Act
            var result = surfboard.Type;

            // Assert
            Assert.AreEqual("Funboard", result);
        
        }

        [TestMethod]
        public void TestSurfboardPrice() 
        {
            // Arrange
            var surfboard = new Surfboard { Price = 700};

            // Act
            var result = surfboard.Price;

            // Assert
            Assert.AreEqual(700, result);
        
        }

        [TestMethod]
        public void TestSurfboardName() 
        {
            // Arrange
            var surfboard = new Surfboard { Name = "The Golden Ration" };

            // Act
            var result = surfboard.Name;

            // Assert
            Assert.AreEqual("The Golden Ration", result);
        }

        [TestMethod]
        public void TestSurfboardEquipment()
        {
            // Arrange
            var surfboard = new Surfboard { Equipment = " " };

            // Act
            var result = surfboard.Equipment;

            // Assert
            Assert.AreEqual(" ", result);
        }
    }

}
