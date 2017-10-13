using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class TopicsService : ITopicsService
    {
        private readonly IEfGenericRepository<Topic> topics;

        public TopicsService(IEfGenericRepository<Topic> topics)
        {
            Guard.WhenArgument(topics, "topics").IsNull().Throw();

            this.topics = topics;
        }

        public IQueryable<Topic> GetAll()
        {
            return this.topics.All();
        }

        public Topic GetById(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            return this.topics.GetById(id);
        }

        public void Create(Topic topic)
        {
            Guard.WhenArgument(topic, "topic").IsNull().Throw();

            this.topics.Add(topic);
            this.topics.SaveChanges();
        }

        public void Update(Topic topic)
        {
            Guard.WhenArgument(topic, "topic").IsNull().Throw();

            this.topics.Update(topic);
            this.topics.SaveChanges();
        }

        public void Delete(Topic topic)
        {
            Guard.WhenArgument(topic, "topic").IsNull().Throw();

            this.topics.Delete(topic);
            this.topics.SaveChanges();
        }
    }
}
