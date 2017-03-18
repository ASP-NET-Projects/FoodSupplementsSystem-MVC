using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;

namespace FoodSupplementsSystem.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public Category Create(string name)
        {
            var category = new Category() { Name = name };

            this.categories.Add(category);

            this.categories.SaveChanges();

            return category;
        }

        public void UpdateNameById(int id, string name)
        {
            this.categories.GetById(id).Name = name;

            this.categories.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.categories.Delete(id);

            this.categories.SaveChanges();
        }
    }
}
