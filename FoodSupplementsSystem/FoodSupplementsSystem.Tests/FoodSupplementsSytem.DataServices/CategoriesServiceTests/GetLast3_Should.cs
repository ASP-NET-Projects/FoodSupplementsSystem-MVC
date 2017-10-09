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
    public class GetLast3_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollectionLast3 = DataHelper.GetCategories().Take(3);
            categories.Setup(x => x.Last3()).Returns(categoriesCollectionLast3);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetLast3();

            //Assert
            Assert.IsInstanceOf<IQueryable<Category>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollectionLast3 = DataHelper.GetCategories().Take(3);
            categories.Setup(x => x.Last3()).Returns(categoriesCollectionLast3);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, categoriesCollectionLast3);
        }

        [Test]
        public void ReturnCorrectCollectionCount()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollectionLast3 = DataHelper.GetCategories().Take(3);
            categories.Setup(x => x.Last3()).Returns(categoriesCollectionLast3);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, categoriesCollectionLast3);
            Assert.AreEqual(result.Count(), categoriesCollectionLast3.Count());
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollectionLast3 = DataHelper.GetCategories().Take(3);
            categories.Setup(x => x.Last3()).Returns(categoriesCollectionLast3);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, categoriesCollectionLast3);
            Assert.AreEqual(result.FirstOrDefault().Id, categoriesCollectionLast3.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Name, categoriesCollectionLast3.FirstOrDefault().Name);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodLast3_ReturnsNull()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            categories.Setup(x => x.Last3()).Returns(() => null);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetLast3();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosLast3Once()
        {
            //Arrange
            var categories = new Mock<IEfGenericRepository<Category>>();
            var categoriesCollectionLast3 = DataHelper.GetCategories().Take(3);
            categories.Setup(x => x.Last3()).Returns(categoriesCollectionLast3);
            var categoriesService = new CategoriesService(categories.Object);

            //Act
            var result = categoriesService.GetLast3();

            //Assert
            categories.Verify(x => x.Last3(), Times.Once);
        }
    }
}
