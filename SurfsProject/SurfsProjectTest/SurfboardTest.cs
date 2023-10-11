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

    }
}
