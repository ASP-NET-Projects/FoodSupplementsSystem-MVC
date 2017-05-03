using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.BrandsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstance_WhenParameterIsNotNull()
        {
            //Arrange
            var brandsMocked = new Mock<IEfGenericRepository<Brand>>();
            BrandsService brandsService = new BrandsService(brandsMocked.Object);

            //Act & Assert
            Assert.IsInstanceOf<IBrandsService>(brandsService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Arrange
            IEfGenericRepository<Brand> nullRepository = null;

            //Act & Assert
            Assert.That(
                () => new BrandsService(nullRepository),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
