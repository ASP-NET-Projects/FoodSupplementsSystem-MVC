using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Services.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var homeService = new Mock<IHomeService>();

            var controller = new HomeController(homeService.Object);

            // Act & Assert
            Assert.IsInstanceOf<HomeController>(controller);
        }

        [Test]
        public void ThrowException_WhenParameterIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(null));
        }
    }
}