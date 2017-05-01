using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.CategoriesControllerTests
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
            CategoriesController categoriesController = new CategoriesController(categoriesServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<CategoriesController>(categoriesController);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CategoriesController(null));
        }
    }
}
