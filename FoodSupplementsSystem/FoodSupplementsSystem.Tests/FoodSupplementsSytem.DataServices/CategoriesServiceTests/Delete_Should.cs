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
    public class Delete_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.Delete(null));
        }

        [Test]
        public void InvokeRepositoryMethosDeleteOnce()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            categories.Setup(x => x.Delete(It.IsAny<Category>())).Verifiable();
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            categoriesService.Delete(category);

            //Assert
            categories.Verify(x => x.Delete(It.IsAny<Category>()), Times.Once);
        }
    }
}
