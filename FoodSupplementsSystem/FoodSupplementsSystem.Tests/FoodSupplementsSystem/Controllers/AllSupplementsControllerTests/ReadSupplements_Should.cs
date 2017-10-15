using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using AutoMapper;
using Kendo.Mvc.UI;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllSupplementsControllerTests
{
    [TestFixture]
    public class ReadSupplements_Should
    {
        [TestFixtureSetUp]
        public void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Supplement, ListSupplementViewModel>();
                cfg.CreateMap<ListSupplementViewModel, Supplement>();
            });
        }

        [Test]
        public void ReturnJsonResult_WhenGetToReadSupplements()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var supplements = DataHelper.GetSupplements();
            var categoryId = 1;
            var brandId = 1;
            var topicId = 1;
            var kendoDataRequest = new DataSourceRequest();

            supplementsService.Setup(x => x.GetAll()).Returns(supplements);

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            controller.WithCallTo(c => c.ReadSupplements(kendoDataRequest, categoryId, brandId, topicId)).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModelInstance_WhenGetToReadSupplements()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var supplements = DataHelper.GetSupplements();
            var categoryId = 1;
            var brandId = 1;
            var topicId = 1;
            var kendoDataRequest = new DataSourceRequest();

            supplementsService.Setup(x => x.GetAll()).Returns(supplements);

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act
            var controllerResult = controller.ReadSupplements(kendoDataRequest, categoryId, brandId, topicId);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<ListSupplementViewModel>;

            //Assert
            Assert.IsInstanceOf<IList<ListSupplementViewModel>>(results);
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToReadSupplements()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var supplements = DataHelper.GetSupplements();
            var categoryId = 1;
            var brandId = 1;
            var topicId = 1;
            var kendoDataRequest = new DataSourceRequest();

            supplementsService.Setup(x => x.GetAll()).Returns(supplements);

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act
            var controllerResult = controller.ReadSupplements(kendoDataRequest, categoryId, brandId, topicId);
            var jsonResult = controllerResult as JsonResult;
            dynamic kendoResultData = jsonResult.Data;
            var results = kendoResultData.Data as IEnumerable<ListSupplementViewModel>;

            var expectedResult = Mapper.Map<List<ListSupplementViewModel>>(supplements.Where(s => s.CategoryId == categoryId && s.BrandId == brandId && s.TopicId == topicId));

            //Assert
            Assert.AreEqual(expectedResult, results);
        }
    }
}
