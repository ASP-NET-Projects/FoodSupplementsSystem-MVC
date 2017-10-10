using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.SupplementsServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollection = DataHelper.GetSupplements();
            supplements.Setup(x => x.All()).Returns(supplementsCollection);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetAll();

            //Assert
            Assert.IsInstanceOf<IQueryable<Supplement>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollection = DataHelper.GetSupplements();
            supplements.Setup(x => x.All()).Returns(supplementsCollection);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, supplementsCollection);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollection = DataHelper.GetSupplements();
            supplements.Setup(x => x.All()).Returns(supplementsCollection);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, supplementsCollection);
            Assert.AreEqual(result.FirstOrDefault().Id, supplementsCollection.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Name, supplementsCollection.FirstOrDefault().Name);
            Assert.AreEqual(result.FirstOrDefault().ImageUrl, supplementsCollection.FirstOrDefault().ImageUrl);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodAll_ReturnsNull()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            supplements.Setup(x => x.All()).Returns(() => null);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetAll();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosAllOnce()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollection = DataHelper.GetSupplements();
            supplements.Setup(x => x.All()).Returns(supplementsCollection);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetAll();

            //Assert
            supplements.Verify(x => x.All(), Times.Once);
        }
    }
}
