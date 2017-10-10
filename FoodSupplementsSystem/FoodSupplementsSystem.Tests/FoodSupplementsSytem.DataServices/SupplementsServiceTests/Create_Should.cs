using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.SupplementsServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsService = new SupplementsService(supplements.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => supplementsService.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            supplements.Setup(x => x.Add(It.IsAny<Supplement>())).Verifiable();
            var supplementsService = new SupplementsService(supplements.Object);
            var supplement = DataHelper.GetSupplement();

            //Act
            supplementsService.Create(supplement);

            //Assert
            supplements.Verify(x => x.Add(It.IsAny<Supplement>()), Times.Once);
        }
    }
}
