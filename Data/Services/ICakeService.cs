using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Data.ViewModels;
using DarsBakeryv3.Models;
using System.Linq.Expressions;

namespace DarsBakeryv3.Data.Services
{
    public interface ICakeService : IEntityBaseRepository<Cake>
    {
        
        Task<Cake> GetCakeByIdAsync(int id);
        Task<NewCakeDropdownsVM> GetNewCakeDropdownsValues();
        Task AddNewCakeAsync(NewCakeVM data);
        Task UpdateCakeAsync(NewCakeVM data);
    }
}
