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
    public class GetTopics_Should
    {
        [Test]
        public void ReturnJsonResult_WhenGetToGetTopics()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var topicsService = new Mock<ITopicsService>();
            var topics = DataHelper.GetTopicsSelectedCollection();
            var topicsPopulator = DataHelper.GetSelectListItemCollection();
            topicsService.Setup(x => x.GetAll()).Returns(topics);
            dropDownListPopulator.Setup(x => x.GetTopics()).Returns(topicsPopulator);

            AutoMapperConfig.Config();

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            controller.WithCallTo(x => x.GetTopics()).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToGetBrands()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var topicsService = new Mock<ITopicsService>();
            var topics = DataHelper.GetTopicsSelectedCollection();
            var topicsPopulator = DataHelper.GetSelectListItemCollection();
            topicsService.Setup(x => x.GetAll()).Returns(topics);
            dropDownListPopulator.Setup(x => x.GetTopics()).Returns(topicsPopulator);

            AutoMapperConfig.Config();

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            controller.WithCallTo(x => x.GetTopics()).ShouldReturnJson(data =>
            {
                Assert.AreEqual(data, topicsPopulator);
            });
        }
    }
}
