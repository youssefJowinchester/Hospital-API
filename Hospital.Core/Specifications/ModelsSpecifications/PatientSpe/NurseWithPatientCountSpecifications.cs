using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.PatientSpe
{
    public class NurseWithPatientCountSpecifications : BaseSpecifications<Nurse>
    {

        public NurseWithPatientCountSpecifications(int patientId, SpecParams nurseSpec) : base(p => p.Patients.Any(pd => pd.PatientId == patientId))
        {
            if (!string.IsNullOrEmpty(nurseSpec.Search))
            {
                Criteira = p => p.Patients.Any(pd => pd.PatientId == patientId) &&
                                p.Name.ToLower().Contains(nurseSpec.Search);
            }
        }

    }
}
