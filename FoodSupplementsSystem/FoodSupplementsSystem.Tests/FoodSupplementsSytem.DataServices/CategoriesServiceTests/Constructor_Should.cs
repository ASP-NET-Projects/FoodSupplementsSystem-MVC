using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Services.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstance_WhenParameterIsNotNull()
        {
            //Arrange
            var categoriesMocked = new Mock<IRepository<Category>>();
            CategoriesService categoriesService = new CategoriesService(categoriesMocked.Object);

            //Act & Assert
            Assert.IsInstanceOf<ICategoriesService>(categoriesService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Arrange
            IRepository<Category> nullRepository = null;

            //Act & Assert
            Assert.That(
                () => new CategoriesService(nullRepository),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
