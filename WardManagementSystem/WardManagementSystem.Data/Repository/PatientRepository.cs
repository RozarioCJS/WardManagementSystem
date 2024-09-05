using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public PatientRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<bool> AddPatientAsync(Patient patients)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeletePatientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetPatientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePatientAsync(Patient patient)
        {
            throw new NotImplementedException();
        }

        Task<int> IPatientRepository.AddPatientAsync(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
