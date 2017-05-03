using System.Collections.Generic;
using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.SupplementsServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void Invoke_TheRepositoryMethodGetAll_Once()
        {
            //Arrange
            var supplementsMock = new Mock<IEfGenericRepository<Supplement>>();
            SupplementsService SupplementsService = new SupplementsService(supplementsMock.Object);

            //Act
            IQueryable<Supplement> supplementResult = SupplementsService.GetAll();

            //Assert
            supplementsMock.Verify(c => c.All(), Times.Once);
        }

        [Test]
        public void ReturnResult_WhenInvokingRepositoryMethod_GetAll()
        {
            //Arrange
            var supplementsMock = new Mock<IEfGenericRepository<Supplement>>();
            IQueryable<Supplement> expectedResultCollection = new List<Supplement>().AsQueryable();

            supplementsMock.Setup(c => c.All()).Returns(() =>
            {
                return expectedResultCollection;
            });

            SupplementsService supplementsService = new SupplementsService(supplementsMock.Object);

            //Act
            IQueryable<Supplement> supplementResult = supplementsService.GetAll();

            //Assert
            Assert.That(supplementResult, Is.EqualTo(expectedResultCollection));
        }

        [Test]
        public void ReturnResultOfCorrectType()
        {
            //Arrange
            var supplementsMock = new Mock<IEfGenericRepository<Supplement>>();

            supplementsMock.Setup(c => c.All()).Returns(() =>
            {
                IQueryable<Supplement> expectedResultCollection = new List<Supplement>().AsQueryable();
                return expectedResultCollection;
            });

            SupplementsService supplementsService = new SupplementsService(supplementsMock.Object);

            //Act
            IQueryable<Supplement> supplementResult = supplementsService.GetAll();

            //Assert
            Assert.That(supplementResult, Is.InstanceOf<IQueryable<Supplement>>());
        }

        [Test]
        public void ReturnNull_WhenReposityMethodGetAll_ReturnsNull()
        {
            //Arrange
            var supplementsMock = new Mock<IEfGenericRepository<Supplement>>();

            supplementsMock.Setup(c => c.All()).Returns(() =>
            {
                return null;
            });

            SupplementsService supplementsService = new SupplementsService(supplementsMock.Object);

            //Act
            IQueryable<Supplement> supplementResult = supplementsService.GetAll();

            //Assert
            Assert.IsNull(supplementResult);
        }
    }
}
