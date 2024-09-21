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
        Task<int> AddUserAsync(string UserName, string Password, string Role);
        Task<bool> AddUserDetailsAsync(int UserID, string FirstName, string LastName, string ContactNumber, string Email, string Address1, string Address2, string Role);
        Task<bool> UpdateUserAsync(int UserID, string ContactNumber, string Role);
        Task<bool> DeleteUserAsync(int id);

        Task<UserViewModel> GetUserByIdAsync(int Id);

        Task<IEnumerable<User>> GetAllUserAsync();
    }
}
