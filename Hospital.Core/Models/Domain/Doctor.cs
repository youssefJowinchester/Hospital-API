using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Enums;
using Hospital.Core.Models.Identity;

namespace Hospital.Core.Models.Domain
{
    public class Doctor : ContactInfo
    {

        public decimal Rate { get; set; }
        public Major  Major { get; set; }
        public Position Position { get; set; }
        public decimal Salary { get; set; }

        public ICollection<Bill> Bills { get; set; }

        public ICollection<MedicalHistory> medicalHistories { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
       
        public ICollection<Patients_Doctors> Patients { get; set; }

        public ICollection<Nurse> Nurses { get; set; }

    }
}
