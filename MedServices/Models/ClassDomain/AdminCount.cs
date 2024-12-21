using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Models.ClassDomain
{
    public class AdminCount
    {
       public int? TotalPatients { get; set; }
       public int? TotalUsers { get; set; }
       public int? TotalMedication { get; set; }
       public List<AdminDashboard> ?Chart { get; set; }
    }
}
