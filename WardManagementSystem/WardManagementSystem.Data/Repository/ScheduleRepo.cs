using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public class ScheduleRepo : IScheduleRepo
    {
        private readonly ISqlDataAccess _db;
        public ScheduleRepo(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Schedule schedule)
        {
            try
            {
                await _db.SaveData("sp_CreateSchedule", new { schedule.PatientID, schedule.DoctorID, schedule.Date, schedule.Time });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeleteSchedule", new { ScheduleID = id});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public async Task<IEnumerable<Schedule>> GetAllAsync()
        //{
        //    string query = "sp_ViewAllSchedules";
        //    return await _db.GetData<Schedule, dynamic>(query, new { });
        //}

        public async Task<Schedule> GetByIdAsync(int id)
        {
            IEnumerable<Schedule> result = await _db.GetData<Schedule, dynamic>("sp_FindSchedule", new { ScheduleID = id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Schedule schedule)
        {
            try
            {
                await _db.SaveData("sp_UpdateSchedule", schedule);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<IEnumerable<DoctorDashboardViewModel>> GetAllTodayAsync(int DoctorID)
        {
            return await _db.GetData<DoctorDashboardViewModel, dynamic>("sp_VisitsScheduledToday", new { DoctorID = DoctorID });
        }

        public async Task<IEnumerable<DoctorDashboardViewModel>> GetAllTotalAsync(int DoctorID)
        {
            return await _db.GetData<DoctorDashboardViewModel, dynamic>("sp_TotalVisitsScheduled", new { DoctorID = DoctorID });
        }

        public async Task<IEnumerable<DoctorDashboardViewModel>> GetDashboardAsync(int DoctorID)
        {
            return await _db.GetData<DoctorDashboardViewModel, dynamic>("sp_DashboardSchedule", new { DoctorID = DoctorID });
        }

        public async Task<IEnumerable<ScheduleDisplayViewModel>> GetAllAsync()      //still have to code it in a way that uses DoctorID to only display specif doctor's schedule. Code to be updated in stored procedure as well!!
        {
            string query = "sp_ViewAllSchedulesVM";
            return await _db.GetData<ScheduleDisplayViewModel, dynamic>(query, new { });
        }

        public async Task<IEnumerable<ScheduleDisplayViewModel>> GetAllPatientAsync(int PatientID)      //still have to code it in a way that uses DoctorID to only display specif doctor's schedule. Code to be updated in stored procedure as well!!
        {
            string query = "sp_ViewPatientSchedulesVM";
            return await _db.GetData<ScheduleDisplayViewModel, dynamic>(query, new { PatientID = PatientID});
        }

        public async Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync()
        {
            var query = "sp_DoctorFullName";
            return await _db.GetData<DoctorFullNameViewModel, dynamic>(query, new { });
        }

        public async Task<IEnumerable<PatientFullNameViewModel>> GetPatientFullNameAsync()
        {
            var query = "sp_PatientFullName";
            return await _db.GetData<PatientFullNameViewModel, dynamic>(query, new { });
        }
    }
}
