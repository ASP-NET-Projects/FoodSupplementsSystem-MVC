using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;

using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllComments;
using FoodSupplementsSystem.ViewModels.AllTopics;

namespace FoodSupplementsSystem.Controllers
{
    public class AllTopicsController : Controller
    {
        private ITopicsService topics;

        private ICommentsService comments;

        public AllTopicsController(ITopicsService topics, ICommentsService comments)
        {
            this.topics = topics;
            this.comments = comments;
        }

        public ActionResult Details(int id)
        {
            var topic = this.topics
                .GetAll()
                .Where(t => t.Id == id)
                .ProjectTo<TopicDetailsViewModel>()
                .FirstOrDefault();

            if (topic == null)
            {
                throw new HttpException(404, "Topic not found");
            }

            topic.Comments = this.comments
                .GetAll()
                .Where(c => c.TopicId == topic.Id)
                .OrderByDescending(c => c.Id)
                .ProjectTo<CommentViewModel>()
                .ToList();

            return View(topic);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var resultTopics = this.topics.GetAll().Include(t => t.Supplements).ProjectTo<TopicViewModel>().ToList();

            return View(resultTopics);
        }
    }
}