using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();
    }
}