using Bytes2you.Validation;
using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Data.Repositories;
using FoodSupplementsSystem.Services.Data.Contracts;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data
{
    public class SupplementsService : ISupplementsService
    {
        private IRepository<Supplement> supplements;

        public SupplementsService(IRepository<Supplement> supplements)
        {
            Guard.WhenArgument(supplements, "supplements").IsNull().Throw();

            this.supplements = supplements;
        }

        public IQueryable<Supplement> GetAll()
        {
            return this.supplements.All();
        }
    }
}
