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
    public class Update_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsNull()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsService = new SupplementsService(supplements.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => supplementsService.Update(null));
        }

        [Test]
        public void InvokeRepositoryMethodUpdateOnce()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            supplements.Setup(x => x.Update(It.IsAny<Supplement>())).Verifiable();
            var supplementsService = new SupplementsService(supplements.Object);
            var supplement = DataHelper.GetSupplement();

            //Act
            supplementsService.Update(supplement);

            //Assert
            supplements.Verify(x => x.Update(It.IsAny<Supplement>()), Times.Once);
        }
    }
}
