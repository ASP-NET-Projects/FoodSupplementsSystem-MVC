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
    public class GetById_Should
    {
        [Test]
        public void Throw_WhenIdParameterIsInvalid()
        {
            // Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var invalidSupplementId = 0;
            var supplementsService = new SupplementsService(supplements.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => supplementsService.GetById(invalidSupplementId));
        }

        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplement = DataHelper.GetSupplement();
            var supplementId = supplement.Id;
            supplements.Setup(x => x.GetById(It.IsAny<int>())).Returns(supplement);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetById(supplementId);

            //Assert
            Assert.IsInstanceOf<Supplement>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplement = DataHelper.GetSupplement();
            var supplementId = supplement.Id;
            supplements.Setup(x => x.GetById(It.IsAny<int>())).Returns(supplement);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetById(supplementId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, supplement);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplement = DataHelper.GetSupplement();
            var supplementId = supplement.Id;
            supplements.Setup(x => x.GetById(It.IsAny<int>())).Returns(supplement);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetById(supplementId);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, supplement);
            Assert.AreEqual(result.Id, supplement.Id);
            Assert.AreEqual(result.Name, supplement.Name);
            Assert.AreEqual(result.ImageUrl, supplement.ImageUrl);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodGetById_ReturnsNull()
        {
            //Arrange
            var supplementId = 1;
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            supplements.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetById(supplementId);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosGetByIdOnce()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplement = DataHelper.GetSupplement();
            var supplementId = supplement.Id;
            supplements.Setup(x => x.GetById(It.IsAny<int>())).Returns(supplement);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetById(supplementId);

            //Assert
            supplements.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
