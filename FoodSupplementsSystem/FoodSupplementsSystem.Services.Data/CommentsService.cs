﻿using Bytes2you.Validation;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private IRepository<Comment> comments;

        public CommentsService(IRepository<Comment> comments)
        {
            Guard.WhenArgument(comments, "comments").IsNull().Throw();

            this.comments = comments;
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All();
        }
    }
}