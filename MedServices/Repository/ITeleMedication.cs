using MedServices.Models.ClassDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Repository
{
    public interface ITeleMedication
    {
        //Landing page login Validation
        Task<User> ValidateUser(string email, string password);
        Task<int> TotalPatients();
        Task<int> TotalnoUsers();
        Task<int> TotalMedication();
        Task<List<AdminDashboard>> UserCount();
        //Patients Dashboard getting appointments based on Status eg... Completed ,pending 
        Task<IEnumerable<AppointmentDetail>> AppointmentDetails(string status);
    }
}
