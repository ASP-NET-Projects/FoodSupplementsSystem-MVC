using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllSupplementsControllerTests
{
    [TestFixture]
    public class GetCategories_Should
    {
        [Test]
        public void ReturnJsonResult_WhenGetToGetCategories()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var categoriesService = new Mock<ICategoriesService>();
            var categories = DataHelper.GetCategoriesSelectedCollection();
            var categoriesPopulator = DataHelper.GetSelectListItemCollection();
            categoriesService.Setup(x => x.GetAll()).Returns(categories);
            dropDownListPopulator.Setup(x => x.GetCategories()).Returns(categoriesPopulator);

            AutoMapperConfig.Config();

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            controller.WithCallTo(x => x.GetCategories()).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToGetCategories()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var categoriesService = new Mock<ICategoriesService>();
            var categories = DataHelper.GetCategoriesSelectedCollection();
            var categoriesPopulator = DataHelper.GetSelectListItemCollection();
            categoriesService.Setup(x => x.GetAll()).Returns(categories);
            dropDownListPopulator.Setup(x => x.GetCategories()).Returns(categoriesPopulator);

            AutoMapperConfig.Config();

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            controller.WithCallTo(x => x.GetCategories()).ShouldReturnJson(data =>
            {
                Assert.AreEqual(data, categoriesPopulator);
            });
        }
    }
}
