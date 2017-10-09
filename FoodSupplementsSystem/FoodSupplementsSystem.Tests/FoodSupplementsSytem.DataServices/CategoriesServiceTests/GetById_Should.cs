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
    public class GetById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            // Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var invalidGategoryId = 0;
            categories.Setup(x => x.GetById(It.IsAny<int>())).Returns(category);
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => categoriesService.GetById(invalidGategoryId));
        }

        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryId = category.Id;
            categories.Setup(x => x.GetById(It.IsAny<int>())).Returns(category);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetById(categoryId);

            //Assert
            Assert.IsInstanceOf<Category>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryId = category.Id;
            categories.Setup(x => x.GetById(It.IsAny<int>())).Returns(category);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetById(categoryId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, category);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryId = category.Id;
            categories.Setup(x => x.GetById(It.IsAny<int>())).Returns(category);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetById(categoryId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, category);
            Assert.AreEqual(result.Id, category.Id);
            Assert.AreEqual(result.Name, category.Name);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodGetById_ReturnsNull()
        {
            //Arrange
            var categoryId = 1;
            var categories = new Mock<IEfGenericRepository<Category>>();
            categories.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetById(categoryId);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosGetByIdOnce()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            var categoryId = category.Id;
            categories.Setup(x => x.GetById(It.IsAny<int>())).Returns(category);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetById(categoryId);

            //Assert
            categories.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
