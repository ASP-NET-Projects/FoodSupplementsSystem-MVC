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
            var supplementsMocked = new Mock<IRepository<Supplement>>();
            SupplementsService supplementsService = new SupplementsService(supplementsMocked.Object);

            //Act & Assert
            Assert.IsInstanceOf<ISupplementsService>(supplementsService);
        }

        [Test]
        public void Throw_WhenNullParameterIsPassed()
        {
            //Arrange
            IRepository<Supplement> nullRepository = null;

            //Act & Assert
            Assert.That(
                () => new SupplementsService(nullRepository),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
