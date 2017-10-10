using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.BrandsServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollection = DataHelper.GetBrands();
            brands.Setup(x => x.All()).Returns(brandsCollection);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetAll();

            //Assert
            Assert.IsInstanceOf<IQueryable<Brand>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollection = DataHelper.GetBrands();
            brands.Setup(x => x.All()).Returns(brandsCollection);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brandsCollection);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollection = DataHelper.GetBrands();
            brands.Setup(x => x.All()).Returns(brandsCollection);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brandsCollection);
            Assert.AreEqual(result.FirstOrDefault().Id, brandsCollection.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Name, brandsCollection.FirstOrDefault().Name);
            Assert.AreEqual(result.FirstOrDefault().WebSite, brandsCollection.FirstOrDefault().WebSite);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodAll_ReturnsNull()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            brands.Setup(x => x.All()).Returns(() => null);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetAll();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosAllOnce()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollection = DataHelper.GetBrands();
            brands.Setup(x => x.All()).Returns(brandsCollection);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetAll();

            //Assert
            brands.Verify(x => x.All(), Times.Once);
        }
    }
}
