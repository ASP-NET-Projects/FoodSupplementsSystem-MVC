using System.Linq;

using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        IQueryable<Category> GetLast3();

        Category GetById(int id);

        void Create(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}
