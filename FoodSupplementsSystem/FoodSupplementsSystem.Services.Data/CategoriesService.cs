using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private IEfGenericRepository<Category> categories;

        public CategoriesService(IEfGenericRepository<Category> categories)
        {
            Guard.WhenArgument(categories, "categories").IsNull().Throw();

            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }

        public IQueryable<Category> GetLast3()
        {
            return this.categories.Last3();
        }

        public Category GetById(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            return this.categories.GetById(id);
        }

        public Category Create(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            var category = new Category { Name = name };

            this.categories.Add(category);

            this.categories.SaveChanges();

            return category;
        }

        public void UpdateNameById(int id, string name)
        {
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            Guard.WhenArgument(name, "name").IsNull().Throw();

            this.categories.GetById(id).Name = name;

            this.categories.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            this.categories.Delete(id);

            this.categories.SaveChanges();
        }
    }
}
