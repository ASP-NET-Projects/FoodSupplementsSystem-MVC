using System;
using System.Web.Mvc;

using AutoMapper;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllFeedbacks;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllFeedbacksController : UserController
    {
        private IFeedbacksService feedbacks;

        public AllFeedbacksController(IFeedbacksService feedbacks, IEfGenericRepository<ApplicationUser> repoUser)
            : base(repoUser)
        {
            this.feedbacks = feedbacks;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackViewModel feedback)
        {
            if (!ModelState.IsValid)
            {
                return View(feedback);
            }

            var dbFeedback = Mapper.Map<Feedback>(feedback);
            dbFeedback.CreationDate = DateTime.UtcNow;
            dbFeedback.Author = this.UserProfile;
            this.feedbacks.Create(dbFeedback);

            this.TempData["Notification"] = "Thank you for your feedback!";
            return this.Redirect("/");
        }
    }
}