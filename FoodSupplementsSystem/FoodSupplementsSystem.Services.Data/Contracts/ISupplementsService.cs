using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ISupplementsService
    {
        IQueryable<Supplement> GetAll();

        Supplement GetById(int id);

        void Create(Supplement supplement);

        Supplement Create(string name, string imageUrl, string ingredients, string use, string description);

        void UpdateById(int id, string name, string imageUrl, string ingredients, string use, string description);

        void DeleteById(int id);
    }
}
