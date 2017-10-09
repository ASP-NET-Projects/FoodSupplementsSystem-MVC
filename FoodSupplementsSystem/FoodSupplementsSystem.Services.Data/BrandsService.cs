using System.Linq;

using Bytes2you.Validation;

using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;

namespace FoodSupplementsSystem.Services.Data
{
    public class BrandsService : IBrandsService
    {
        private IEfGenericRepository<Brand> brands;

        public BrandsService(IEfGenericRepository<Brand> brands)
        {
            Guard.WhenArgument(brands, "brands").IsNull().Throw();

            this.brands = brands;
        }

        public IQueryable<Brand> GetAll()
        {
            return this.brands.All();
        }

        public IQueryable<Brand> GetLast3()
        {
            return this.brands.Last3();
        }

        public Brand GetById(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(1).Throw();

            return this.brands.GetById(id);
        }

        public void Create(Brand brand)
        {
            Guard.WhenArgument(brand, "brand").IsNull().Throw();

            this.brands.Add(brand);
            this.brands.SaveChanges();
        }

        public void Update(Brand brand)
        {
            Guard.WhenArgument(brand, "brand").IsNull().Throw();

            this.brands.Update(brand);
            this.brands.SaveChanges();
        }

        public void Delete(Brand brand)
        {
            Guard.WhenArgument(brand, "brand").IsNull().Throw();

            this.brands.Delete(brand);
            this.brands.SaveChanges();
        }
    }
}
