using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Models.ClassDomain
{
    public class Medication
    {
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public string Description { get; set; }
        public string DosageForm { get; set; }
        public string Strength { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
