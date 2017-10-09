using System.Linq;

using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSytem.DataServices.CommentsServiceTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnCorrectInstance()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            var commentsCollection = DataHelper.GetComments();
            comments.Setup(x => x.All()).Returns(commentsCollection);
            var commentsService = new CommentsService(comments.Object);

            //Act
            var result = commentsService.GetAll();

            //Assert
            Assert.IsInstanceOf<IQueryable<Comment>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            var commentsCollection = DataHelper.GetComments();
            comments.Setup(x => x.All()).Returns(commentsCollection);
            var commentsService = new CommentsService(comments.Object);

            //Act
            var result = commentsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, commentsCollection);
        }

        [Test]
        public void ReturnCorrectModelWithRightProperties()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            var commentsCollection = DataHelper.GetComments();
            comments.Setup(x => x.All()).Returns(commentsCollection);
            var commentsService = new CommentsService(comments.Object);

            //Act
            var result = commentsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, commentsCollection);
            Assert.AreEqual(result.FirstOrDefault().Id, commentsCollection.FirstOrDefault().Id);
            Assert.AreEqual(result.FirstOrDefault().Content, commentsCollection.FirstOrDefault().Content);
            Assert.AreEqual(result.FirstOrDefault().CreationDate, commentsCollection.FirstOrDefault().CreationDate);
        }

        [Test]
        public void ReturnNull_WhenRepositoryMethodAll_ReturnsNull()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            comments.Setup(x => x.All()).Returns(() => null);
            var commentsService = new CommentsService(comments.Object);

            //Act
            var result = commentsService.GetAll();

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void InvokeRepositoryMethosAllOnce()
        {
            //Arrange
            var comments = new Mock<IEfGenericRepository<Comment>>();
            var commentsCollection = DataHelper.GetComments();
            comments.Setup(x => x.All()).Returns(commentsCollection);
            var commentsService = new CommentsService(comments.Object);

            //Act
            var result = commentsService.GetAll();

            //Assert
            comments.Verify(x => x.All(), Times.Once);
        }
    }
}
