using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Enums;
using Hospital.Core.Models.Identity;

namespace Hospital.Core.Models.Domain
{
    public class Patient : ContactInfo
    {
        public BloodType BloodType { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Patients_Doctors> Doctors { get; set; }
        public ICollection<Patients_Nurses> Nurses { get; set; }
        public ICollection<MedicalHistory> MedicalHistories { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
