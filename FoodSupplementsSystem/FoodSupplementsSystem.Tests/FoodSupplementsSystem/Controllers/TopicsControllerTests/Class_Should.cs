using System;

using NUnit.Framework;

using FoodSupplementsSystem.Areas.Administration.Controllers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.TopicsControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifyTopicsController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(TopicsController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
