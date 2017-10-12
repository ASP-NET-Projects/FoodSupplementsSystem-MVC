using System;

using FoodSupplementsSystem.Controllers;

using NUnit.Framework;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllCommentsControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifyAllCategoriesController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(AllCommentsController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
