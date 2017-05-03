using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private IEfGenericRepository<Comment> comments;

        public CommentsService(IEfGenericRepository<Comment> comments)
        {
            Guard.WhenArgument(comments, "comments").IsNull().Throw();

            this.comments = comments;
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All();
        }

        public void Create(Comment comment)
        {
            Guard.WhenArgument(comment, "comment").IsNull().Throw();

            this.comments.Add(comment);
            this.comments.SaveChanges();
        }
    }
}
