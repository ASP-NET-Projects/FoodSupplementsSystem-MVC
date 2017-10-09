using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstance_WhenParameterIsNotNull()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.IsInstanceOf<ICategoriesService>(categoriesService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(()=>new CategoriesService(null));
        }
    }
}
