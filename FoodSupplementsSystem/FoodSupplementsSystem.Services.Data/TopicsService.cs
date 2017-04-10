using Bytes2you.Validation;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data
{
    public class TopicsService : ITopicsService
    {
        private IRepository<Topic> topics;

        public TopicsService(IRepository<Topic> topics)
        {
            this.topics = topics;
        }

        public IQueryable<Topic> GetAll()
        {
            return this.topics.All();
        }

        public Topic GetById(int id)
        {
            return this.topics.GetById(id);
        }

        public void Create(Topic topic)
        {
            Guard.WhenArgument(topic, "topic").IsNull().Throw();

            this.topics.Add(topic);
            this.topics.SaveChanges();
        }

        public void UpdateById(int id, Topic updateTopic)
        {
            var topicToUpdate = this.topics.GetById(id);

            topicToUpdate.Name = updateTopic.Name;
            topicToUpdate.Description = updateTopic.Description;

            this.topics.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.topics.Delete(id);
            this.topics.SaveChanges();
        }
    }
}
