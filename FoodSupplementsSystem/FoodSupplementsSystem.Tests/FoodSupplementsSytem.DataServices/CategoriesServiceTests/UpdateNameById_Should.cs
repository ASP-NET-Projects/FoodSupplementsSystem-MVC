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
    public class UpdateNameById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryName = category.Name;
            var inavlidCategoryId = 0;
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => categoriesService.UpdateNameById(inavlidCategoryId, categoryName));
        }

        [Test]
        public void Throw_WhenNameParameterIsNull()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryId = category.Id;
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.UpdateNameById(categoryId, null));
        }

        [Test]
        public void InvokeRepositoryMethosGetByIdOnce()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryId = category.Id;
            var categoryName = category.Name;
            categories.Setup(x => x.GetById(It.IsAny<int>())).Returns(category);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            categoriesService.UpdateNameById(categoryId, categoryName);

            //Assert
            categories.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
