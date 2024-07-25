using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Models.Identity;

namespace Hospital.Core.Models.Domain
{
    public class Nurse : ContactInfo
    {

        public decimal Rate { get; set; }
        public decimal Salary { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public ICollection<Patients_Nurses> Patients { get; set; }

    }
}
