using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.SupplementsServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstance_WhenParameterIsNotNull()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsService = new SupplementsService(supplements.Object);

            //Act & Assert
            Assert.IsInstanceOf<ISupplementsService>(supplementsService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SupplementsService(null));
        }
    }
}
