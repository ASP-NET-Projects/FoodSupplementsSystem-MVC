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
    public class Delete_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsService = new BrandsService(brands.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => brandsService.Delete(null));
        }

        [Test]
        public void InvokeRepositoryMethodDeleteOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            brands.Setup(x => x.Delete(It.IsAny<Brand>())).Verifiable();
            var brandsService = new BrandsService(brands.Object);
            var brand = DataHelper.GetBrand();

            //Act
            brandsService.Delete(brand);

            //Assert
            brands.Verify(x => x.Delete(It.IsAny<Brand>()), Times.Once);
        }
    }
}
