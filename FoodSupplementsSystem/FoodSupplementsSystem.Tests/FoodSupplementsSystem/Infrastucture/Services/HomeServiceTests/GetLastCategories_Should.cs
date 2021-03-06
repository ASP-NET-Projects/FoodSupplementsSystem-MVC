﻿using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using Moq;
using NUnit.Framework;

using FoodSupplementsSystem.Infrastructure.Services;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllCategories;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Infrastucture.Services.HomeServiceTests
{ 
    [TestFixture]
    public class GetLastCategories_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<Supplement, SupplementViewModel>();
                cfg.CreateMap<SupplementViewModel, Supplement>();
            });
        }

        [Test]
        public void ReturnCorrectModelInstance()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var categoriesCollection = DataHelper.GetCategories().Take(3);
            categories.Setup(x => x.GetLast3()).Returns(categoriesCollection);

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act
            var result = homeService.GetLastCategories();

            //Assert
            Assert.IsInstanceOf<IList<CategoryViewModel>>(result);
        }

        [Test]
        public void ReturnCorrectModel()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            var categoriesCollection = DataHelper.GetCategories().Take(3);
            categories.Setup(x => x.GetLast3()).Returns(categoriesCollection);

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);
            var expectedResult = Mapper.Map<IList<CategoryViewModel>>(categoriesCollection);

            //Act
            var result = homeService.GetLastCategories();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResult.Count, result.Count);
            Assert.AreEqual(expectedResult.FirstOrDefault().Id, result.FirstOrDefault().Id);
            Assert.AreEqual(expectedResult.FirstOrDefault().Name, result.FirstOrDefault().Name);
        }

        [Test]
        public void ReturnNullReferenceException_WhenServiceMethodGetLast3ReturnsNull()
        {
            //Arrange
            var topics = new Mock<ITopicsService>();
            var brands = new Mock<IBrandsService>();
            var categories = new Mock<ICategoriesService>();
            var supplements = new Mock<ISupplementsService>();
            categories.Setup(x => x.GetLast3()).Returns(() => null);

            var homeService = new HomeService(topics.Object, brands.Object, categories.Object, supplements.Object);

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => homeService.GetLastCategories());
        }
    }
}
