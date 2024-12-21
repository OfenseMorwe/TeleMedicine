using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Models.ClassDomain
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; } // Foreign key to Patient
        public int DoctorID { get; set; } // Foreign key to Doctor
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Status { get; set; } // E.g., "Scheduled", "Completed", "Canceled"
        public string Notes { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
