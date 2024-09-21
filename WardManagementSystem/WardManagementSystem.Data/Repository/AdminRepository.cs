﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using static iText.IO.Image.Jpeg2000ImageData;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WardManagementSystem.Data.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ISqlDataAccess _db;
        public AdminRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        //User Management
        public async Task<int> AddUserAsync(string UserName, string Password, string Role)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@UserName", UserName);
            parameters.Add("@Password", Password);
            parameters.Add("@Role", Role);
            parameters.Add("@UserID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _db.SaveData("sp_AddUserAdmin", parameters);

            return parameters.Get<int>("UserID");

        }
        public async Task<bool> AddUserDetailsAsync(int UserID, string FirstName, string LastName, string ContactNumber, string Email, string Address1, string Address2, string Role)
        {
            try
            {
                await _db.SaveData("sp_AddUserDetail", new { FirstName, LastName, ContactNumber, Email, Address1, Address2, Role, UserID });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeleteUser", new { UserID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<UserViewModel> GetUserByIdAsync(int Id)
        {
            IEnumerable<UserViewModel> result = await _db.GetData<UserViewModel, dynamic>("sp_GetEmployeeDetail", new { UserID = Id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateUserAsync(int UserID, string ContactNumber, string Role)
        {
            try
            {

                await _db.SaveData("sp_UpdateUser", new { UserID, ContactNumber, Role });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _db.GetData<User, dynamic>("sp_GetAllUsers", new { });
        }


        //Ward Management
        public async Task<bool> AddWardAsync(Ward ward)
        {
            try
            {
                await _db.SaveData("sp_AddWard", new { ward.WardName, ward.WardNumber});
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateWardAsync(int WardID, string WardName)
        {
            try
            {

                await _db.SaveData("sp_UpdateWard", new { WardID, WardName });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteWardAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeleteWard", new { WardID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Ward>> GetAllWardAsync()
        {
            return await _db.GetData<Ward, dynamic>("spGetWards", new { });
        }

        public async Task<Ward> GetByIdAsync(int Id)
        {
            IEnumerable<Ward> result = await _db.GetData<Ward, dynamic>("spGetWardsByID", new { UserID = Id });

            return result.FirstOrDefault();
        }


    }
}
