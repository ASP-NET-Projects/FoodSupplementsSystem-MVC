using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.BrandsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var brandsService = new Mock<IBrandsService>();

            // Act
            var controller = new BrandsController(brandsService.Object);

            // Assert
            Assert.IsInstanceOf<BrandsController>(controller);
        }

        [Test]
        public void ThrowException_WhenParameterIsNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BrandsController(null));
        }
    }
}
