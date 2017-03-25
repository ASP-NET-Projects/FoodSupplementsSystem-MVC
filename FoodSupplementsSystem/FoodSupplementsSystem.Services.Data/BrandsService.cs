using Bytes2you.Validation;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data
{
    public class BrandsService : IBrandsService
    {
        private IRepository<Brand> brands;

        public BrandsService(IRepository<Brand> brands)
        {
            Guard.WhenArgument(brands, "brands").IsNull().Throw();

            this.brands = brands;
        }

        public IQueryable<Brand> GetAll()
        {
            return this.brands.All();
        }
    }
}
