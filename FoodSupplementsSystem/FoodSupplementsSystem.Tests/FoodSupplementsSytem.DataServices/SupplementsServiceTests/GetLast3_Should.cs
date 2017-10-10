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
    public class GetLast3_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollectionLast3 = DataHelper.GetSupplements().Take(3);
            supplements.Setup(x => x.Last3()).Returns(supplementsCollectionLast3);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetLast3();

            //Assert
            Assert.IsInstanceOf<IQueryable<Supplement>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollectionLast3 = DataHelper.GetSupplements().Take(3);
            supplements.Setup(x => x.Last3()).Returns(supplementsCollectionLast3);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, supplementsCollectionLast3);
        }

        [Test]
        public void ReturnCorrectCollectionCount()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollectionLast3 = DataHelper.GetSupplements().Take(3);
            supplements.Setup(x => x.Last3()).Returns(supplementsCollectionLast3);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, supplementsCollectionLast3);
            Assert.AreEqual(result.Count(), supplementsCollectionLast3.Count());
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollectionLast3 = DataHelper.GetSupplements().Take(3);
            supplements.Setup(x => x.Last3()).Returns(supplementsCollectionLast3);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetLast3();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, supplementsCollectionLast3);
            Assert.AreEqual(result.FirstOrDefault().Id, supplementsCollectionLast3.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Name, supplementsCollectionLast3.FirstOrDefault().Name);
            Assert.AreEqual(result.FirstOrDefault().ImageUrl, supplementsCollectionLast3.FirstOrDefault().ImageUrl);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodLast3_ReturnsNull()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            supplements.Setup(x => x.Last3()).Returns(() => null);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetLast3();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosLast3Once()
        {
            //Arrange
            var supplements = new Mock<IEfGenericRepository<Supplement>>();
            var supplementsCollectionLast3 = DataHelper.GetSupplements().Take(3);
            supplements.Setup(x => x.Last3()).Returns(supplementsCollectionLast3);
            var supplementsService = new SupplementsService(supplements.Object);

            //Act
            var result = supplementsService.GetLast3();

            //Assert
            supplements.Verify(x => x.Last3(), Times.Once);
        }
    }
}
