using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllBrands;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Infrastucture.Services.HomeServiceTests
{
    [TestFixture]
    public class GetLastBrands_Should
    {
        [Test]
        public void ReturnCorrectModelInstance()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var brandsCollection = DataHelper.GetBrands().Take(3);
            brands.Setup(x => x.GetLast3()).Returns(brandsCollection);

            AutoMapperConfig.Config();

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act
            var result = homeService.GetLastBrands();

            //Assert
            Assert.IsInstanceOf<IList<BrandViewModel>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var brandsCollection = DataHelper.GetBrands().Take(3);
            brands.Setup(x => x.GetLast3()).Returns(brandsCollection);

            AutoMapperConfig.Config();

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);
            var expectedResult = Mapper.Map<IList<BrandViewModel>>(brandsCollection);

            //Act
            var result = homeService.GetLastBrands();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult.Count, result.Count);
            Assert.AreEqual(expectedResult.FirstOrDefault().Id, result.FirstOrDefault().Id);
            Assert.AreEqual(expectedResult.FirstOrDefault().Name, result.FirstOrDefault().Name);
            Assert.AreEqual(expectedResult.FirstOrDefault().WebSite, result.FirstOrDefault().WebSite);
        }

        [Test]
        public void ReturnNullReferenceException_WhenServiceMethodGetLast3ReturnsNull()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            brands.Setup(x => x.GetLast3()).Returns(() => null);

            AutoMapperConfig.Config();

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => homeService.GetLastBrands());
        }
    }
}
