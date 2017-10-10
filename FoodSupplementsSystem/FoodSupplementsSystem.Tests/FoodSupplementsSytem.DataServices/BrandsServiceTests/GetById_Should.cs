using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.BrandsServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            // Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var invalidBrandId = 0;
            var brandsService = new BrandsService(brands.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => brandsService.GetById(invalidBrandId));
        }

        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brand = DataHelper.GetBrand();
            var brandId = brand.Id;
            brands.Setup(x => x.GetById(It.IsAny<int>())).Returns(brand);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetById(brandId);

            //Assert
            Assert.IsInstanceOf<Brand>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brand = DataHelper.GetBrand();
            var brandId = brand.Id;
            brands.Setup(x => x.GetById(It.IsAny<int>())).Returns(brand);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetById(brandId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brand);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brand = DataHelper.GetBrand();
            var brandId = brand.Id;
            brands.Setup(x => x.GetById(It.IsAny<int>())).Returns(brand);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetById(brandId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, brand);
            Assert.AreEqual(result.Id, brand.Id);
            Assert.AreEqual(result.Name, brand.Name);
            Assert.AreEqual(result.WebSite, brand.WebSite);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodGetById_ReturnsNull()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandId = 1;
            brands.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetById(brandId);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosGetByIdOnce()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brand = DataHelper.GetBrand();
            var brandId = brand.Id;
            brands.Setup(x => x.GetById(It.IsAny<int>())).Returns(brand);
            var brandsService = new BrandsService(brands.Object);

            //Act
            var result = brandsService.GetById(brandId);

            //Assert
            brands.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
