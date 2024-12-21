using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MedServices.Models.ClassDomain;
namespace MedServices.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _Config;

        public SqlDataAccess(IConfiguration config)
        {
            _Config = config;
        }

        // Retrieving all data from the database
        public async Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string ConString = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_Config.GetConnectionString(ConString));
            return await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string spName, T parameters, string ConString = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_Config.GetConnectionString(ConString));
            await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
        }

        // Retrieving scalar value from the database
        public async Task<T> GetScalarValue<T, P>(string spName, P parameters, string ConString = "DefaultConnection")
        {
            using (IDbConnection connection = new SqlConnection(_Config.GetConnectionString(ConString)))
            {
                return await connection.ExecuteScalarAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> LoadData<T>(string spName, object parameters = null, string conString = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_Config.GetConnectionString(conString));

            return await connection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
