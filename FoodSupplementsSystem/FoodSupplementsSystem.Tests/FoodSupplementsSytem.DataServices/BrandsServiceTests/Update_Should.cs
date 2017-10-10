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
    public class Update_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsService = new BrandsService(brands.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => brandsService.Update(null));
        }

        [Test]
        public void InvokeRepositoryMethodUpdateOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            brands.Setup(x => x.Update(It.IsAny<Brand>())).Verifiable();
            var brandsService = new BrandsService(brands.Object);
            var brand = DataHelper.GetBrand();

            //Act
            brandsService.Update(brand);

            //Assert
            brands.Verify(x => x.Update(It.IsAny<Brand>()), Times.Once);
        }
    }
}
