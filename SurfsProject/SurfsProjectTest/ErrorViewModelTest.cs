using SurfsProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SurfsProject.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SurfsProjectTest
{
	[TestClass]
	public class TestErrorViewModel
	{
		[TestMethod]
		public void TestShowRequestId ()
		{
			// Arrange
			var errorViewModel = new ErrorViewModel { RequestId = "123"};

			// Act
			var result = errorViewModel.ShowRequestId;

			// Assert
			Assert.IsTrue(result);
		} 

	}
}

