using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Models.Domain
{
    public class Patients_Nurses
    {
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int NurseId { get; set; }

        public Nurse Nurse { get; set; }
    }
}
