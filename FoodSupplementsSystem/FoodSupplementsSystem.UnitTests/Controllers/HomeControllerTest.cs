﻿using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Services.Contracts;

namespace FoodSupplementsSystem.UnitTests.Controllers
{

    [TestClass]
    public class HomeControllerTest
    {
       [TestMethod]
       public void Index()
       {
            // Arrange
            var homeService = new Mock<IHomeService>();

            var controller = new HomeController(homeService.Object);
       
           // Act
           ViewResult result = controller.Index() as ViewResult;
       
           // Assert
           Assert.IsNotNull(result);
       }

      //[TestMethod]
      //public void About()
      //{
      //     // Arrange
      //     var categoriesServiceMock = new Mock<ICategoriesService>();
      //     var brandsServiceMock = new Mock<IBrandsService>();
      //     var supplementsServiceMock = new Mock<ISupplementsService>();
      //     HomeController controller = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object);
      //     
      //     // Act
      //     ViewResult result = controller.About() as ViewResult;
      //
      //    // Assert
      //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
      //}
      //
      //[TestMethod]
      //public void Contact()
      //{
      //     // Arrange
      //     var categoriesServiceMock = new Mock<ICategoriesService>();
      //     var brandsServiceMock = new Mock<IBrandsService>();
      //     var supplementsServiceMock = new Mock<ISupplementsService>();
      //     HomeController controller = new HomeController(categoriesServiceMock.Object, brandsServiceMock.Object, supplementsServiceMock.Object);
      //
      //     // Act
      //     ViewResult result = controller.Contact() as ViewResult;
      //
      //    // Assert
      //    Assert.IsNotNull(result);
      //}
    }
}
