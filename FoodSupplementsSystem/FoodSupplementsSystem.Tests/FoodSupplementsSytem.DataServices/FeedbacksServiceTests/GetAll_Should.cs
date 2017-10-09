using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.FeedbacksServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            var feedbacksCollection = DataHelper.GetFeedbacks();
            feedbacks.Setup(x => x.All()).Returns(feedbacksCollection);
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act
            var result = feedbacksService.GetAll();

            //Assert
            Assert.IsInstanceOf<IQueryable<Feedback>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            var feedbacksCollection = DataHelper.GetFeedbacks();
            feedbacks.Setup(x => x.All()).Returns(feedbacksCollection);
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act
            var result = feedbacksService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, feedbacksCollection);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            var feedbacksCollection = DataHelper.GetFeedbacks();
            feedbacks.Setup(x => x.All()).Returns(feedbacksCollection);
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act
            var result = feedbacksService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, feedbacksCollection);
            Assert.AreEqual(result.FirstOrDefault().Id, feedbacksCollection.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Title, feedbacksCollection.FirstOrDefault().Title);
            Assert.AreEqual(result.FirstOrDefault().Content, feedbacksCollection.FirstOrDefault().Content);
            Assert.AreEqual(result.FirstOrDefault().CreationDate, feedbacksCollection.FirstOrDefault().CreationDate);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodAll_ReturnsNull()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            feedbacks.Setup(x => x.All()).Returns(() => null);
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act
            var result = feedbacksService.GetAll();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosAllOnce()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            var feedbacksCollection = DataHelper.GetFeedbacks();
            feedbacks.Setup(x => x.All()).Returns(feedbacksCollection);
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act
            var result = feedbacksService.GetAll();

            //Assert
            feedbacks.Verify(x => x.All(), Times.Once);
        }
    }
}
