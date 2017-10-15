using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.Home;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Infrastucture.Services.HomeServiceTests
{
    [TestFixture]
    public class GetTopicViewModel_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Topic, HomeTopicViewModel>();
                cfg.CreateMap<HomeTopicViewModel, Topic>();
            });
        }

        [Test]
        public void Throw_WhenPassedParameterIsNotValid()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var numberOfTopics = -1;

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => homeService.GetTopicViewModel(numberOfTopics));
        }

        [Test]
        public void ReturnCorrectModelInstance_WhenPassedParameterIsValid()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var numberOfTopics = 6;
            var topicsCollection = DataHelper.GetTopics();
            topics.Setup(x => x.GetAll()).Returns(topicsCollection);

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act
            var result = homeService.GetTopicViewModel(numberOfTopics);

            //Assert
            Assert.IsInstanceOf<IList<HomeTopicViewModel>>(result);
        }

        [Test]
        public void ReturnCorrectModel_WhenPassedParameterIsValid()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var numberOfTopics = 6;
            var topicsCollection = DataHelper.GetTopics();
            topics.Setup(x => x.GetAll()).Returns(topicsCollection);

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            var expectedResultWithDataModel = topicsCollection.OrderByDescending(t => t.Comments.Count()).Take(numberOfTopics)
                .ToList();
            var expectedResult = Mapper.Map<IList<HomeTopicViewModel>>(expectedResultWithDataModel);

            //Act
            var result = homeService.GetTopicViewModel(numberOfTopics);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult.FirstOrDefault().Id, result.FirstOrDefault().Id);
            Assert.AreEqual(expectedResult.FirstOrDefault().Name, result.FirstOrDefault().Name);
            Assert.AreEqual(expectedResult.FirstOrDefault().Description, result.FirstOrDefault().Description);
            Assert.AreEqual(expectedResult.FirstOrDefault().NumberOfComments, result.FirstOrDefault().NumberOfComments);
            Assert.AreEqual(expectedResult.FirstOrDefault().NumberOfSupplements, result.FirstOrDefault().NumberOfSupplements);
        }

        [Test]
        public void ThrowArgumentNullException_WhenServiceMethodGetAllReturnsNull()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var numberOfTopics = 6;
            topics.Setup(x => x.GetAll()).Returns(() => null);

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => homeService.GetTopicViewModel(numberOfTopics));
        }
    }
}
