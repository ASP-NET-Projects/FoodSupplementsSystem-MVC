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
    public class Create_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesService = new CategoriesService(categories.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => categoriesService.Create(null));
        }

        [Test]
        public void ReturnCorrectInstance_WhenPassedParameterIsValid()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            categories.Setup(x => x.Add(It.IsAny<Category>())).Verifiable();
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.Create(category.Name);

            //Assert
            Assert.IsInstanceOf<Category>(result);
        }

        [Test]
        public void ReturnCorrectModel_WhenPassedParameterIsValid()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var category = DataHelper.GetCategory();
            categories.Setup(x => x.Add(It.IsAny<Category>())).Verifiable();
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.Create(category.Name);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(category.Name, result.Name);
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            categories.Setup(x => x.Add(It.IsAny<Category>())).Verifiable();
            var categoriesService = new CategoriesService(categories.Object);
            var category = DataHelper.GetCategory();

            //Act
            categoriesService.Create(category.Name);

            //Assert
            categories.Verify(x => x.Add(It.IsAny<Category>()), Times.Once);
        }
    }
}
