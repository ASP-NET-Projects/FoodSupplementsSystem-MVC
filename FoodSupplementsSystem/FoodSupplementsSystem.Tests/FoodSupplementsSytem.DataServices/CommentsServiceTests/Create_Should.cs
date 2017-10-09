using System;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CommentsServiceTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Throw_WhenPassedParameterIsNull()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            var commentsService = new CommentsService(comments.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => commentsService.Create(null));
        }

        [Test]
        public void InvokeRepositoryMethodAddOnce_WhenPassedParameterIsValid()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            var comment = DataHelper.GetComment();
            comments.Setup(x => x.Add(It.IsAny<Comment>())).Verifiable();
            var commentsService = new CommentsService(comments.Object);

            //Act
            commentsService.Create(comment);

            //Assert
            comments.Verify(x => x.Add(It.IsAny<Comment>()), Times.Once);
        }
    }
}
