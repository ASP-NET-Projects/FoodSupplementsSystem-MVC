using System;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using FoodSupplementsSystem.Areas.Administration.ViewModels;
using FoodSupplementsSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using AutoMapper.QueryableExtensions;

namespace FoodSupplementsSystem.Areas.Administration.Controllers
{
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
                this.topics.Create(topic.Name, topic.Description);
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
                    this.topics.UpdateNameById(topic.Id, topic.Name);
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
                    this.topics.DeleteById(topic.Id);
                }
            }

            return Json(new[] { topic }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
