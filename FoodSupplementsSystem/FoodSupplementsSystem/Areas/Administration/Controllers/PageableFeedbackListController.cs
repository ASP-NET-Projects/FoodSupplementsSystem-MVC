using System;
using System.Linq;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;

using FoodSupplementsSystem.Areas.Administration.ViewModels.PageableFeedbackList;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PageableFeedbackListController : Controller
    {
        const int ItemsPerPage = 6;

        private readonly IFeedbacksService feedbacks;

        public PageableFeedbackListController(IFeedbacksService feedbacks)
        {
            this.feedbacks = feedbacks;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.feedbacks.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var feedbacks = this.feedbacks.GetAll()
                .OrderBy(x => x.CreationDate)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .ProjectTo<FeedbackViewModel>().ToList();

            var viewModel = new ListFeedbackViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Feedbacks = feedbacks
            };

            return View(viewModel);
        }
    }
}