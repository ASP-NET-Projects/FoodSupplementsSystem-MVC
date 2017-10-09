using System.Linq;

using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface IBrandsService
    {
        IQueryable<Brand> GetAll();

        IQueryable<Brand> GetLast3();

        Brand GetById(int id);

        void Create(Brand brand);

        void Update(Brand brand);

        void Delete(Brand brand);

        //void DeleteById(int id);
    }
}
