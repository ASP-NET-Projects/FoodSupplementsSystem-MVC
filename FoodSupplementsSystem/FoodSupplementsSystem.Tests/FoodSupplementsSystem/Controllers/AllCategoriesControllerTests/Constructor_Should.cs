using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllCategoriesControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();

            // Act
            AllCategoriesController categoriesController = new AllCategoriesController(categoriesServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<AllCategoriesController>(categoriesController);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllCategoriesController(null));
        }
    }
}
