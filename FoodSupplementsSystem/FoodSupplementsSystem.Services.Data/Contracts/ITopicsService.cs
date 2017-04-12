using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ITopicsService
    {
        IQueryable<Topic> GetAll();

        Topic GetById(int id);

        void UpdateById(int id, string name, string description);

        void DeleteById(int id);

        Topic Create(string name, string description);
    }
}