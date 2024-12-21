using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Models.ClassDomain
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int PatientID { get; set; } // Foreign key to Patient
        public int DoctorID { get; set; } // Foreign key to Doctor
        public int MedicationID { get; set; } // Foreign key to Medication
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Notes { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Medication Medication { get; set; }
    }
}
