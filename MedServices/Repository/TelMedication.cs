using Dapper;
using MedServices.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MedServices.Models.ClassDomain;

namespace MedServices.Repository
{
    public class TelMedication : ITeleMedication
    {
        private readonly ISqlDataAccess _sql;
        public TelMedication(ISqlDataAccess sql)
        {
            _sql = sql;

        }
        public async Task<User> ValidateUser(string email , string password)
        {
            string Query = "ValidateUser_sp";
            IEnumerable<User> results = await _sql.GetData<User, dynamic>(Query, new { Email = email, Password = password });
            return results.FirstOrDefault();
        }
        public async Task<int> TotalPatients()
        {
            return await _sql.GetScalarValue<int, dynamic>("CountPatients", new { }); 
        }
        public async Task<int> TotalnoUsers()
        {
            return await _sql.GetScalarValue<int, dynamic>("CountNumUsers", new { });
        }
        public async Task<int> TotalMedication()
        {
            return await _sql.GetScalarValue<int, dynamic>("CountNumMedic", new { });
        }
        public async Task<IEnumerable<AppointmentDetail>> AppointmentDetails(string status)
        {
            IEnumerable<AppointmentDetail> details = await _sql.GetData<AppointmentDetail, dynamic>("GetAppointmentsDetailsByStatus", new { Status = status });
            return details;
        }
        public async Task<List<AdminDashboard>> UserCount()
        {
            IEnumerable<AdminDashboard> ChartResults = await _sql.GetData<AdminDashboard, dynamic>("GetUserAndRoleCounts", new { });
            return ChartResults.ToList();
        }
    }
}
