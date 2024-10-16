using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public interface IScheduleRepo
    {
        Task<bool> AddAsync(Schedule schedule, int DoctorID);
        Task<bool> UpdateAsync(Schedule schedule);
        Task<bool> DeleteAsync(int id);
        Task<Schedule> GetByIdAsync(int id);
        //Task<IEnumerable<Schedule>> GetAllAsync(); //will later be changed to all by Doctor (Can be done with the sql statement, should'nt have to change code).
        Task<IEnumerable<DoctorDashboardViewModel>> GetAllTodayAsync(int DoctorID);     //Get total scheduled for today only
        Task<IEnumerable<DoctorDashboardViewModel>> GetAllTotalAsync(int DoctorID);     //Get total scheduled for doctor
        Task<IEnumerable<DoctorDashboardViewModel>> GetDashboardAsync(int DoctorID);    //Get the data for the scheduled today table
        Task<IEnumerable<ScheduleDisplayViewModel>> GetAllAsync();
        Task<IEnumerable<ScheduleDisplayViewModel>> GetAllPatientAsync(int PatientID, int DoctorID); //Gets all the schedules for a specific patient
        Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync();        //used to fill drop down list with doctor name
        Task<IEnumerable<PatientFullNameViewModel>> GetPatientFullNameAsync();
    }
}
