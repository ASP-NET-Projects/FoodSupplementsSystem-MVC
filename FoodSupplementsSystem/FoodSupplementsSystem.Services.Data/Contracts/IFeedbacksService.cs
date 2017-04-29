using FoodSupplementsSystem.Data.Models;
using System.Linq;

namespace FoodSupplementsSystem.Services.Data.Contracts
{
    public interface IFeedbacksService
    {
        IQueryable<Feedback> GetAll();

        void Create(Feedback feedback);
    }
}