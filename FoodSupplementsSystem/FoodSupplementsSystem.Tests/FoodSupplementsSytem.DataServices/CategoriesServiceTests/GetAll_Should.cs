using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CategoriesServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollection = DataHelper.GetCategories();
            categories.Setup(x => x.All()).Returns(categoriesCollection);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetAll();

            //Assert
            Assert.IsInstanceOf<IQueryable<Category>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollection = DataHelper.GetCategories();
            categories.Setup(x => x.All()).Returns(categoriesCollection);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, categoriesCollection);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollection = DataHelper.GetCategories();
            categories.Setup(x => x.All()).Returns(categoriesCollection);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, categoriesCollection);
            Assert.AreEqual(result.FirstOrDefault().Id, categoriesCollection.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Name, categoriesCollection.FirstOrDefault().Name);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodAll_ReturnsNull()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            categories.Setup(x => x.All()).Returns(() => null);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetAll();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosAllOnce()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollection = DataHelper.GetCategories();
            categories.Setup(x => x.All()).Returns(categoriesCollection);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetAll();

            //Assert
            categories.Verify(x => x.All(), Times.Once);
        }
    }
}
