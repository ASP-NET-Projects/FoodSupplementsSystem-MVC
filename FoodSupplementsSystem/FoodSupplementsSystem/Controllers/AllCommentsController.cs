using AutoMapper;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using FoodSupplementsSystem.ViewModels.AllComments;
using System;
using System.Web;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Controllers
{
    [Authorize]
    public class AllCommentsController : UserController
    {
        private ITopicsService topics;

        private ICommentsService comments;

        public AllCommentsController(ITopicsService topics, ICommentsService comments, IRepository<ApplicationUser> repoUser) 
            : base(repoUser)
        {
            this.topics = topics;
            this.comments = comments;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(PostCommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                var dbComment = Mapper.Map<Comment>(comment);
                var topic = this.topics.GetById(comment.TopicId);
                if (topic == null)
                {
                    throw new HttpException(404, "Topic not found");
                }

                dbComment.TopicId = comment.TopicId;
                dbComment.CreationDate = DateTime.UtcNow;
                dbComment.Author = this.UserProfile;
                this.comments.Create(dbComment);

                var viewModel = Mapper.Map<CommentViewModel>(dbComment);

                return PartialView("_CommentPartial", viewModel);
            }

            throw new HttpException(400, "Invalid comment");
        }
    }
}