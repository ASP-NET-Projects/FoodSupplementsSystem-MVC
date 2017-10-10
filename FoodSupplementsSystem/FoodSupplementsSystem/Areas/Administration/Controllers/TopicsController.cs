using System.Web.Mvc;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using FoodSupplementsSystem.Areas.Administration.ViewModels.Topics;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TopicsController : Controller
    {
        private ITopicsService topics;

        public TopicsController(ITopicsService topics)
        {
            Guard.WhenArgument(topics, "topics").IsNull().Throw();

            this.topics = topics;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Topics_Read([DataSourceRequest]DataSourceRequest request)
        {
            var resultTopics = topics.GetAll().ProjectTo<TopicViewModel>();

            return Json(resultTopics.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Topics_Create([DataSourceRequest]DataSourceRequest request, TopicViewModel topic)
        {
            if (topic != null && this.ModelState.IsValid)
            {
                var topicDbModel = Mapper.Map<Topic>(topic);
                this.topics.Create(topicDbModel);
            }

            return Json(new[] { topic }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Topics_Update([DataSourceRequest]DataSourceRequest request, TopicViewModel topic)
        {
            if (ModelState.IsValid)
            {
                if (topic != null && this.ModelState.IsValid)
                {
                    var topicDbModel = Mapper.Map<Topic>(topic);
                    this.topics.Update(topicDbModel);
                }
            }

            return Json(new[] { topic }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Topics_Destroy([DataSourceRequest]DataSourceRequest request, TopicViewModel topic)
        {
            if (ModelState.IsValid)
            {
                if (topic != null && this.ModelState.IsValid)
                {
                    var topicDbModel = Mapper.Map<Topic>(topic);
                    this.topics.Delete(topicDbModel);
                }
            }

            return Json(new[] { topic }.ToDataSourceResult(request, ModelState));
        }
    }
}
