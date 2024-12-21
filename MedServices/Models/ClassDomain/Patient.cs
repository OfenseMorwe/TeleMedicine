using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Models.ClassDomain
{
    public class Patient
    {
        public int PatientID { get; set; }
        public int UserID { get; set; } // Foreign key to User
        public string MedicalHistory { get; set; }
        public string Allergies { get; set; }
        public string EmergencyContact { get; set; }
        public virtual User User { get; set; } // Navigation property
    }
}
