using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllBrandsControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var brandsServiceMock = new Mock<IBrandsService>();

            // Act
            AllBrandsController brandsController = new AllBrandsController(brandsServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<AllBrandsController>(brandsController);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllBrandsController(null));
        }
    }
}
