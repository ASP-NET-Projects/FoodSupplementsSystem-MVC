using System;

using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.SupplementsControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifySupplementsController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(SupplementsController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
