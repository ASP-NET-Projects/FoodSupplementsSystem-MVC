﻿using FoodSupplementsSystem.Areas.Administration.Controllers;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}