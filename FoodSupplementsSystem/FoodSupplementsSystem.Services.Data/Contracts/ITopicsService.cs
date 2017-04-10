using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ITopicsService
    {
        IQueryable<Topic> GetAll();

        Topic GetById(int id);

        void UpdateById(int id, Topic updateTopic);

        void DeleteById(int id);

        void Create(Topic topic);
    }
}