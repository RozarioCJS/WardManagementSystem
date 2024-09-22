using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public interface IAdminRepository
    {
        //User Management
        Task<int> AddUserAsync(string UserName, string Password, string Role);
        Task<bool> AddUserDetailsAsync(int UserID, string FirstName, string LastName, string ContactNumber, string Email, string Address1, string Address2, string Role);
        Task<bool> UpdateUserAsync(int UserID, string ContactNumber, string Role);
        Task<bool> DeleteUserAsync(int id);

        Task<UserViewModel> GetUserByIdAsync(int Id);

        Task<IEnumerable<User>> GetAllUserAsync();

        //Ward Management
        Task<bool> AddWardAsync(Ward ward);
        Task<bool> UpdateWardAsync(int WardID, string WardName);
        Task<bool> DeleteWardAsync(int id);

        Task<Ward> GetByIdAsync(int id);

        Task<IEnumerable<Ward>> GetAllWardAsync();


        //Consumable Management
        Task<IEnumerable<Consumable>> GetAllConsumablesAsync();
        Task<Consumable> GetConsumableById(int id);
        Task<bool> UpdateConsumableAsync(int ConsumableID, string ConsumableName);
        Task<bool> AddConsumabledAsync(Consumable consumable);
        
        Task<bool> DeleteConsumableAsync(int id);

    }
}
