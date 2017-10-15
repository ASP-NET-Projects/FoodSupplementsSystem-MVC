using System;

using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.PageableFeedbackListControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifyBrandsController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(PageableFeedbackListController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
