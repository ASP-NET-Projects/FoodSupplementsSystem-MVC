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

        public void Create(Category category)
        {
            Guard.WhenArgument(category, "category").IsNull().Throw();

            this.categories.Add(category);
            this.categories.SaveChanges();
        }

        public void Update(Category category)
        {
            Guard.WhenArgument(category, "category").IsNull().Throw();

            this.categories.Update(category);
            this.categories.SaveChanges();
        }

        public void Delete(Category category)
        {
            Guard.WhenArgument(category, "category").IsNull().Throw();

            this.categories.Delete(category);
            this.categories.SaveChanges();
        }
    }
}
