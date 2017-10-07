using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllSupplements;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllSupplementsControllerTests
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void RunDefaultView_WhenGetToAll_WithValidParameters()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var selectedBrnadId = 1;
            var selectedTopicId = 1;
            var selectedCategoryId = 1;

            AutoMapperConfig.Config();

            var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            supplementsController.WithCallTo(c => c.All(selectedCategoryId, selectedBrnadId, selectedTopicId))
                .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnCorrectModelType_WhenGetToAll()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var selectedBrnadId = 1;
            var selectedTopicId = 1;
            var selectedCategoryId = 1;

            AutoMapperConfig.Config();

            var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            supplementsController.WithCallTo(c => c.All(selectedCategoryId, selectedBrnadId, selectedTopicId))
                .ShouldRenderView("All").WithModel<FilterSupplementsViewModel>();
        }

        [Test]
        public void ReturnCorrectResultModel_WhenGetToDetails_WithValidParameters()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var selectedBrnadId = 1;
            var selectedTopicId = 1;
            var selectedCategoryId = 1;

            AutoMapperConfig.Config();

            var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);
            var expectedResult = new FilterSupplementsViewModel { Category = selectedCategoryId, Brand = selectedBrnadId, Topic = selectedTopicId };

            //Act & Assert
            supplementsController.WithCallTo(c => c.All(selectedCategoryId, selectedBrnadId, selectedTopicId))
                .ShouldRenderView("All").WithModel<FilterSupplementsViewModel>(x=> 
                {
                    Assert.AreEqual(x.Category, expectedResult.Category);
                    Assert.AreEqual(x.Brand, expectedResult.Brand);
                    Assert.AreEqual(x.Topic, expectedResult.Topic);
                });
        }

        [Test]
        public void ReturnCorrectResultModel_WhenGetToDetails_WithNullValueParameters()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();

            AutoMapperConfig.Config();

            var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            supplementsController.WithCallTo(c => c.All(null, null, null))
                .ShouldRenderView("All").WithModel<FilterSupplementsViewModel>(x =>
                {
                    Assert.AreEqual(x.Category, null);
                    Assert.AreEqual(x.Brand, null);
                    Assert.AreEqual(x.Topic, null);
                });
        }
    }
}
