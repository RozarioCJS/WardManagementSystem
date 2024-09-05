using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.Domain;

namespace WardManagementSystem.Data.Repository
{
    public interface IScheduleRepo
    {
        Task<bool> AddAsync(Schedule schedule);
        Task<bool> UpdateAsync(Schedule schedule);
        Task<bool> DeleteAsync(int id);
        Task<Schedule> GetByIdAsync(int id);
        Task<IEnumerable<Schedule>> GetAllAsync(); //will later be changed to all by Doctor (Can be done with the sql statement, should'nt have to change code).
        Task<IEnumerable<DoctorDashboardViewModel>> GetAllTodayAsync(int DoctorID);     //Get total scheduled for today only
        Task<IEnumerable<DoctorDashboardViewModel>> GetAllTotalAsync(int DoctorID);     //Get total scheduled for doctor
    }
}
