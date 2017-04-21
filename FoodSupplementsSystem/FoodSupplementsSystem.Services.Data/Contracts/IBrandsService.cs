using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface IBrandsService
    {
        IQueryable<Brand> GetAll();

        IQueryable<Brand> GetLast3();

        Brand GetById(int id);

        Brand Create(string name, string website);

        void UpdateById(int id, string name, string website);

        void DeleteById(int id);
    }
}
