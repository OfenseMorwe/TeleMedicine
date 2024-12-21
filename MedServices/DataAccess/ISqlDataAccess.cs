using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string ConString = "DefaultConnection");
        Task SaveData<T>(string spName, T parameters, string ConString = "DefaultConnection");
        Task<T> GetScalarValue<T, P>(string spName, P parameters, string ConString = "DefaultConnection");
        Task<IEnumerable<T>> LoadData<T>(string spName, object parameters = null, string conString = "DefaultConnection");
    }
}
