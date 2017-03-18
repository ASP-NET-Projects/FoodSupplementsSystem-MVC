﻿using FoodSupplementsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodSupplementsSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
