using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;

namespace FoodSupplementsSystem.Controllers
{
    [HandleError]
    public class UserController : Controller
    {
        protected readonly IEfGenericRepository<ApplicationUser> repoUser;

        protected ApplicationUser UserProfile { get; private set; }

        public UserController(IEfGenericRepository<ApplicationUser> repoUser)
        {
            this.repoUser = repoUser;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.repoUser.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}