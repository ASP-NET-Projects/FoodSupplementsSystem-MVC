using System.Linq;

using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ISupplementsService
    {
        IQueryable<Supplement> GetAll();

        IQueryable<Supplement> GetLast3();

        Supplement GetById(int id);

        void Create(Supplement supplement);

        void Update(Supplement supplement);

        void Delete(Supplement supplement);
    }
}
