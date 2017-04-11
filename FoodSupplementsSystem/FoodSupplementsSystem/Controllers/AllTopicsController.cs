using AutoMapper.QueryableExtensions;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllComments;
using FoodSupplementsSystem.ViewModels.AllTopics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    public class AllTopicsController : Controller
    {
        private ITopicsService topicsService;

        private ICommentsService commentsService;

        public AllTopicsController(ITopicsService topicsService, ICommentsService commentsService)
        {
            this.topicsService = topicsService;
            this.commentsService = commentsService;
        }

        public ActionResult Details(int id)
        {
            var topic = this.topicsService
                .GetAll()
                .Where(t => t.Id == id)
                .ProjectTo<TopicDetailsViewModel>()
                .FirstOrDefault();

           if (topic == null)
           {
               throw new HttpException(404, "Topic not found");
           }
           
           topic.Comments = this.commentsService
               .GetAll()
               .Where(c => c.TopicId == topic.Id)
               .OrderByDescending(c => c.Id)
               .ProjectTo<CommentViewModel>()
               .ToList();
 
            return View(topic);
        }
    }
}