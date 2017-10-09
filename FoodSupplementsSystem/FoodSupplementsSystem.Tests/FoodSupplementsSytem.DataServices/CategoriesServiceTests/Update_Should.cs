using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsNull()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.Update(null));
        }

        [Test]
        public void InvokeRepositoryMethosGetByIdOnce()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            categories.Setup(x => x.Update(It.IsAny<Category>())).Verifiable();
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            categoriesService.Update(category);

            //Assert
            categories.Verify(x => x.Update(It.IsAny<Category>()), Times.Once);
        }
    }
}
