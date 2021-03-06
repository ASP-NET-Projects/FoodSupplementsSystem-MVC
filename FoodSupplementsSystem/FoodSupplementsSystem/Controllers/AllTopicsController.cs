﻿using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper.QueryableExtensions;

using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllComments;
using FoodSupplementsSystem.ViewModels.AllTopics;
using Bytes2you.Validation;

namespace FoodSupplementsSystem.Controllers
{
    public class AllTopicsController : Controller
    {
        private readonly ITopicsService topics;

        private readonly ICommentsService comments;

        public AllTopicsController(ITopicsService topics, ICommentsService comments)
        {
            Guard.WhenArgument(topics, "topics").IsNull().Throw();
            Guard.WhenArgument(comments, "comments").IsNull().Throw();

            this.topics = topics;
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var resultTopics = this.topics.GetAll().Include(t => t.Supplements).ProjectTo<TopicViewModel>().ToList();

            return View(resultTopics);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var topic = this.topics
                .GetAll()
                .Where(t => t.Id == id)
                .ProjectTo<DetailsTopicViewModel>()
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
    }
}