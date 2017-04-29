using System;
using System.Data.Entity;
using FoodSupplementsSystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FoodSupplementsSystem.Data
{
    public class FoodSupplementsSystemDbContext : IdentityDbContext<ApplicationUser>, IFoodSupplementsSystemDbContext
    {
        public FoodSupplementsSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Brand> Brands { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Supplement> Supplements { get; set; }

        public IDbSet<Topic> Topics { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }

        public static FoodSupplementsSystemDbContext Create()
        {
            return new FoodSupplementsSystemDbContext();
        }
    }
}
