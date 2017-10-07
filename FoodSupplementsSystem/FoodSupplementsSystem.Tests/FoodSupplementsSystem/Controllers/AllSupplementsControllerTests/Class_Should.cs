using System;

using NUnit.Framework;

using FoodSupplementsSystem.Controllers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllSupplementsControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifyAllSupplementsController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(AllSupplementsController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
