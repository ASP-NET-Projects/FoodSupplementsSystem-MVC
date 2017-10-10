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
    public class Create_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsService = new BrandsService(brands.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => brandsService.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var brands = new Mock<IEfGenericRepository<Brand>>();
            brands.Setup(x => x.Add(It.IsAny<Brand>())).Verifiable();
            var brandsService = new BrandsService(brands.Object);
            var brand = DataHelper.GetBrand();

            //Act
            brandsService.Create(brand);

            //Assert
            brands.Verify(x => x.Add(It.IsAny<Brand>()), Times.Once);
        }
    }
}
