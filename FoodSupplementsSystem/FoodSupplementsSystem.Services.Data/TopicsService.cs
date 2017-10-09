using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class TopicsService : ITopicsService
    {
        private IEfGenericRepository<Topic> topics;

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

        public Topic Create(string name, string description)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(description, "description").IsNullOrEmpty().Throw();

            var topic = new Topic { Name = name, Description = description };

            this.topics.Add(topic);

            this.topics.SaveChanges();

            return topic;
        }

        public void UpdateById(int id, string name, string description)
        {
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            Guard.WhenArgument(name, "name").IsNull().Throw();

            Guard.WhenArgument(description, "description").IsNull().Throw();

            this.topics.GetById(id).Name = name;

            this.topics.GetById(id).Description = description;

            this.topics.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            this.topics.Delete(id);
            this.topics.SaveChanges();
        }
    }
}
