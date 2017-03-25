using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;

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
            var categoriesWrapperMock = new Mock<IRepository<Category>>();

            // Act
            CategoriesController categoriesController = new CategoriesController(categoriesWrapperMock.Object, categoriesServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<CategoriesController>(categoriesController);
        }

        //[Test]
        //public void ThrowException_WhenParametersAreNull()
        //{
        //    // Arrange & Act & Assert
        //    Assert.Throws<ArgumentNullException>(() => new CategoriesController(null, null));
        //}
    }
}
