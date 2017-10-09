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
    public class DeleteById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var inavlidCategoryId = 0;
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => categoriesService.DeleteById(inavlidCategoryId));
        }

        [Test]
        public void InvokeRepositoryMethosDeleteOnce()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryId = category.Id;
            categories.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            categoriesService.DeleteById(categoryId);

            //Assert
            categories.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
