using FoodSupplementsSystem.Areas.Administration.Controllers;
using NUnit.Framework;
using System;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.CategoriesControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifyCategoriesController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(CategoriesController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
