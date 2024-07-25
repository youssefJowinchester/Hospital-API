using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.PatientSpe
{
    public class DoctorWithPatientCountSpecifications : BaseSpecifications<Doctor>
    {
        public DoctorWithPatientCountSpecifications(int patientId, SpecParams doctorSpec) : base(p => p.Patients.Any(pd => pd.PatientId == patientId))
        {
            if (!string.IsNullOrEmpty(doctorSpec.Search))
            {
                Criteira = p => p.Patients.Any(pd => pd.PatientId == patientId) &&
                                p.Name.ToLower().Contains(doctorSpec.Search);
            }
        }
    }
}
