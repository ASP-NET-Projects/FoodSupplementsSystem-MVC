using FoodSupplementsSystem.Data.Models;
using FoodSupplementsSystem.Infrastructure.Mapping;

namespace FoodSupplementsSystem.ViewModels.AllSupplements
{
    public class SupplementDetailsViewModel : IMapFrom<Supplement>
    {
        public string Name { get; set; }
    }
}