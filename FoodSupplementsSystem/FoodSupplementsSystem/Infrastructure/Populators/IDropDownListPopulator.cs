using System.Collections.Generic;
using System.Web.Mvc;

namespace FoodSupplementsSystem.Infrastructure.Populators
{
    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetCategories();

        IEnumerable<SelectListItem> GetTopics();

        IEnumerable<SelectListItem> GetBrands();
    }
}
