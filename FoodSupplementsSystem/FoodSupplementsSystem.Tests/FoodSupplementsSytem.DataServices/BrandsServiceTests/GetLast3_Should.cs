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
    public class GetLast3_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollectionLast3 = DataHelper.GetBrands().Take(3);
            brands.Setup(x => x.Last3()).Returns(brandsCollectionLast3);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetLast3();

            //Assert
            Assert.IsInstanceOf<IQueryable<Brand>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollectionLast3 = DataHelper.GetBrands().Take(3);
            brands.Setup(x => x.Last3()).Returns(brandsCollectionLast3);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brandsCollectionLast3);
        }

        [Test]
        public void ReturnCorrectCollectionCount()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollectionLast3 = DataHelper.GetBrands().Take(3);
            brands.Setup(x => x.Last3()).Returns(brandsCollectionLast3);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brandsCollectionLast3);
            Assert.AreEqual(result.Count(), brandsCollectionLast3.Count());
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollectionLast3 = DataHelper.GetBrands().Take(3);
            brands.Setup(x => x.Last3()).Returns(brandsCollectionLast3);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brandsCollectionLast3);
            Assert.AreEqual(result.FirstOrDefault().Id, brandsCollectionLast3.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Name, brandsCollectionLast3.FirstOrDefault().Name);
            Assert.AreEqual(result.FirstOrDefault().WebSite, brandsCollectionLast3.FirstOrDefault().WebSite);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodLast3_ReturnsNull()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            brands.Setup(x => x.Last3()).Returns(() => null);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetLast3();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosLast3Once()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsCollectionLast3 = DataHelper.GetBrands().Take(3);
            brands.Setup(x => x.Last3()).Returns(brandsCollectionLast3);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetLast3();

            //Assert
            brands.Verify(x => x.Last3(), Times.Once);
        }
    }
}
