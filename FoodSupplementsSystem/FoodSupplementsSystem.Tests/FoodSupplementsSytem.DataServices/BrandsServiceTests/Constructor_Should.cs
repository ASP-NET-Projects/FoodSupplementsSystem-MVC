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
            var brands = new Mock<IEfGenericRepository<Brand>>();
            var brandsService = new BrandsService(brands.Object);

            //Act & Assert
            Assert.IsInstanceOf<IBrandsService>(brandsService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BrandsService(null));
        }
    }
}
