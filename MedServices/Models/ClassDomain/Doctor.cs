using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Models.ClassDomain
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public int UserID { get; set; } // Foreign key to User
        public string Specialty { get; set; }
        public string LicenseNumber { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public virtual User User { get; set; } // Navigation property
    }
}
