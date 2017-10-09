using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.TopicsServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsCollection = DataHelper.GetTopics();
            topics.Setup(x => x.All()).Returns(topicsCollection);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetAll();

            //Assert
            Assert.IsInstanceOf<IQueryable<Topic>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsCollection = DataHelper.GetTopics();
            topics.Setup(x => x.All()).Returns(topicsCollection);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, topicsCollection);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsCollection = DataHelper.GetTopics();
            topics.Setup(x => x.All()).Returns(topicsCollection);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, topicsCollection);
            Assert.AreEqual(result.FirstOrDefault().Id, topicsCollection.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Name, topicsCollection.FirstOrDefault().Name);
            Assert.AreEqual(result.FirstOrDefault().Description, topicsCollection.FirstOrDefault().Description);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodAll_ReturnsNull()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            topics.Setup(x => x.All()).Returns(() => null);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetAll();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosAllOnce()
        {
            //Arrange
            var topics = new Mock<IEfGenericRepository<Topic>>();
            var topicsCollection = DataHelper.GetTopics();
            topics.Setup(x => x.All()).Returns(topicsCollection);
            var topicsService = new TopicsService(topics.Object);

            //Act
            var result = topicsService.GetAll();

            //Assert
            topics.Verify(x => x.All(), Times.Once);
        }
    }
}
