﻿using System;

using NUnit.Framework;

using FoodSupplementsSystem.Controllers;

namespace FoodSupplementsSystem.Tests.FoodSupplementsSystem.Controllers.AllBrandsControllerTests
{
    [TestFixture]
    public class Class_Should
    {
        [Test]
        public void VerifyAllBrandsController_HasAuthorizeAttribute()
        {
            var attribute = Attribute.GetCustomAttributes(typeof(AllBrandsController), typeof(AuthorAttribute));

            Assert.IsNotNull(attribute);
        }
    }
}
