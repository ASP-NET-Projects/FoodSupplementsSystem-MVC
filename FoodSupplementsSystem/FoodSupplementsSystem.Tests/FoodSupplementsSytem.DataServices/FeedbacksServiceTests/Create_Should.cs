using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.FeedbacksServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => feedbacksService.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var feedbacks = new Mock<IEfGenericRepository<Feedback>>();
            var feedback = DataHelper.GetFeedback();
            feedbacks.Setup(x => x.Add(It.IsAny<Feedback>())).Verifiable();
            var feedbacksService = new FeedbacksService(feedbacks.Object);

            //Act
            feedbacksService.Create(feedback);

            //Assert
            feedbacks.Verify(x => x.Add(It.IsAny<Feedback>()), Times.Once);
        }
    }
}
