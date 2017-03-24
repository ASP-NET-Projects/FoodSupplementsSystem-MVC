using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);

            //Act
            IQueryable<Category> categoryResult = categoriesService.GetAll();

            //Assert
            categoriesMock.Verify(c => c.All(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();
            IQueryable<Category> expectedResultCollection = new List<Category>().AsQueryable();

            categoriesMock.Setup(c => c.All()).Returns(() =>
            {
                return expectedResultCollection;
            });

            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);

            //Act
            IEnumerable<Category> categoryResult = categoriesService.GetAll();

            //Assert
            Assert.That(categoryResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();

            categoriesMock.Setup(c => c.All()).Returns(() =>
            {
                IQueryable<Category> expectedResultCollection = new List<Category>().AsQueryable();
                return expectedResultCollection;
            });

            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);

            //Act
            IQueryable<Category> categoryResult = categoriesService.GetAll();

            //Assert
            Assert.That(categoryResult, Is.InstanceOf<IQueryable<Category>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var categoriesMock = new Mock<IRepository<Category>>();

            categoriesMock.Setup(c => c.All()).Returns(() =>
            {
                return null;
            });

            CategoriesService categoriesService = new CategoriesService(categoriesMock.Object);

            //Act
            IQueryable<Category> categoryResult = categoriesService.GetAll();

            //Assert
            Assert.IsNull(categoryResult);
        }
    }
}
