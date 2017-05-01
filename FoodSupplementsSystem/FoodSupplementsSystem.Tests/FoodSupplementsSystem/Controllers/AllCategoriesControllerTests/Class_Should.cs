using System;

using NUnit.Framework;

using FoodSupplementsSystem.Controllers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllCategoriesControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifyAllCategoriesController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(AllCategoriesController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
