using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodSupplementsSystem.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Supplement> supplements;
        private ICollection<Comment> comments;

        public ApplicationUser()
        {
            this.supplements = new HashSet<Supplement>();
            this.comments = new HashSet<Comment>();
        }

        public virtual ICollection<Supplement> Supplements
        {
            get { return this.supplements; }
            set { this.supplements = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
