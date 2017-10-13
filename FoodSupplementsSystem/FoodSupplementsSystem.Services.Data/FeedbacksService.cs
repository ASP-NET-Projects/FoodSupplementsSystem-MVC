using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class FeedbacksService : IFeedbacksService
    {
        private readonly IEfGenericRepository<Feedback> feedbacks;

        public FeedbacksService(IEfGenericRepository<Feedback> feedbacks)
        {
            Guard.WhenArgument(feedbacks, "feedbacks").IsNull().Throw();

            this.feedbacks = feedbacks;
        }

        public IQueryable<Feedback> GetAll()
        {
            return this.feedbacks.All();
        }

        public void Create(Feedback feedback)
        {
            Guard.WhenArgument(feedback, "feedback").IsNull().Throw();

            this.feedbacks.Add(feedback);
            this.feedbacks.SaveChanges();
        }
    }
}
