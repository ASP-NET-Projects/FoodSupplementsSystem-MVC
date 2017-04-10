﻿using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var brandsServiceMock = new Mock<IBrandsService>();
            var supplementsServiceMock = new Mock<ISupplementsService>();
            var homeServiceMock = new Mock<IHomeService>();

            HomeController homeController = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object, homeServiceMock.Object);

            // Act & Assert
            Assert.IsInstanceOf<HomeController>(homeController);
        }

        [Test]
        public void ThrowException_WhenParametersAreNull()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new HomeController(null, null, null, null));
        }
    }
}