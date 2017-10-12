using System.Linq;

using AutoMapper;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

using FoodSupplementsSystem.App_Start;
using FoodSupplementsSystem.Controllers;
using FoodSupplementsSystem.Infrastructure.Populators;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.Tests.DataHelpers;
using FoodSupplementsSystem.ViewModels.AllSupplements;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllSupplementsControllerTests
{
    [TestFixture]
    public class Details_Should
    {
      [Test]
      public void RunDefaultView_WhenGetToDetails_WithValidSupplementId()
      {
          //Arrange
          var supplementsService = new Mock<ISupplementsService>();
          var dropDownListPopulator = new Mock<IDropDownListPopulator>();
          var supplements = DataHelper.GetSupplements();
          var supplementId = 1;
      
          supplementsService.Setup(x => x.GetAll()).Returns(supplements);
      
          AutoMapperConfig.Config();
      
          var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);
      
      
          //Act & Assert
          supplementsController.WithCallTo(c => c.Details(supplementId))
              .ShouldRenderView("Details");
      }

     [Test]
     public void ReturnCorrectModelType_WhenGetToDetails()
     {
         //Arrange
         var supplementsService = new Mock<ISupplementsService>();
         var dropDownListPopulator = new Mock<IDropDownListPopulator>();
         var supplements = DataHelper.GetSupplements();
         var supplementId = supplements.FirstOrDefault().Id;
     
         supplementsService.Setup(x => x.GetAll()).Returns(supplements);
     
         AutoMapperConfig.Config();
     
         var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);
     
         //Act & Assert
         supplementsController.WithCallTo(c => c.Details(supplementId)).ShouldRenderView("Details").WithModel<DetailsSupplementViewModel>();
     }

      [Test]
      public void ReturnCorrectResultModel_WhenGetToDetails()
      {
          //Arrange
          var supplementsService = new Mock<ISupplementsService>();
          var dropDownListPopulator = new Mock<IDropDownListPopulator>();
          var supplements = DataHelper.GetSupplements();
          var supplementId = supplements.FirstOrDefault().Id;
      
          supplementsService.Setup(x => x.GetAll()).Returns(supplements);
      
          AutoMapperConfig.Config();
      
          var supplementsController = new AllSupplementsController(supplementsService.Object, dropDownListPopulator.Object);
          var expectedResult = Mapper.Map<DetailsSupplementViewModel>(supplements.Where(s=>s.Id==supplementId).FirstOrDefault());
      
          //Act & Assert
          supplementsController.WithCallTo(c => c.Details(supplementId)).ShouldRenderView("Details")
              .WithModel<DetailsSupplementViewModel>(x =>
              {
                  Assert.AreEqual(x.Id, expectedResult.Id);
                  Assert.AreEqual(x.Name, expectedResult.Name);
                  Assert.AreEqual(x.ImageUrl, expectedResult.ImageUrl);
              });
       }
    }
}
