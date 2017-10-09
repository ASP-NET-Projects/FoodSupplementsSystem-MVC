using System.Linq;

using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ITopicsService
    {
        IQueryable<Topic> GetAll();

        Topic GetById(int id);

        void Create(Topic topic);

        void Update(Topic topic);

        void Delete(Topic topic);
    }
}