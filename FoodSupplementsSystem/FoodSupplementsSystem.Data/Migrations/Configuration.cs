using FoodSupplementsSystem.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FoodSupplementsSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<FoodSupplementsSystemDbContext>
    {
        private UserManager<ApplicationUser> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FoodSupplementsSystemDbContext context)
        {
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (context.Supplements.Any())
            {
                return;
            }

            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("Admin"));

            var adminUser = new ApplicationUser
            {
                Email = "admin@mysite.com",
                UserName = "Administrator"
            };

            this.userManager.Create(adminUser, "admin123456");

            this.userManager.AddToRole(adminUser.Id, "Admin");

            var user = new ApplicationUser()
            {
                UserName = "Ana"
            };

            context.Users.Add(user);

            context.SaveChanges();

            var seed = new SeedData(user);

            seed.Categories.ForEach(x => context.Categories.Add(x));

            seed.Topics.ForEach(x => context.Topics.Add(x));

            seed.Brands.ForEach(x => context.Brands.Add(x));

            seed.Supplements.ForEach(x => context.Supplements.Add(x));

            seed.Comments.ForEach(x=>context.Comments.Add(x));

            context.SaveChanges();
        }
    }
}
