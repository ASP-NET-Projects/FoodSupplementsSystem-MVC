using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllSupplementsControllerTests
{
    [TestFixture]
    public class GetBrands_Should
    {
        [Test]
        public void ReturnJsonResult_WhenGetToGetBrands()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var brandsService = new Mock<IBrandsService>();
            var brands = DataHelper.GetBrandsSelectedCollection();
            var brandsPopulator = DataHelper.GetSelectListItemCollection();
            brandsService.Setup(x => x.GetAll()).Returns(brands);
            dropDownListPopulator.Setup(x => x.GetBrands()).Returns(brandsPopulator);

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            controller.WithCallTo(x => x.GetBrands()).ShouldReturnJson();
        }

        [Test]
        public void ReturnJsonResultWithCorrectModel_WhenGetToGetBrands()
        {
            //Arrange
            var supplementsService = new Mock<ISupplementsService>();
            var dropDownListPopulator = new Mock<IDropDownListPopulator>();
            var brandsService = new Mock<IBrandsService>();
            var brands = DataHelper.GetBrandsSelectedCollection();
            var brandsPopulator = DataHelper.GetSelectListItemCollection();
            brandsService.Setup(x => x.GetAll()).Returns(brands);
            dropDownListPopulator.Setup(x => x.GetBrands()).Returns(brandsPopulator);

            var controller = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);

            //Act & Assert
            controller.WithCallTo(x => x.GetBrands()).ShouldReturnJson(data =>
            {
                Assert.AreEqual(data, brandsPopulator);
            });
        }
    }
}
