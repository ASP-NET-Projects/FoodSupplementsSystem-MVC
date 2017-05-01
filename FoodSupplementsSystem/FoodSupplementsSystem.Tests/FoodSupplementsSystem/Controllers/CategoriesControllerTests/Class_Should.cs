using System;

using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;

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
