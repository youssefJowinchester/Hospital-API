using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.DoctorSpe
{
    public class PatientwithCountSpecifications : BaseSpecifications<Patient>
    {
        public PatientwithCountSpecifications(int doctorId, SpecParams patientSpec) : base(p => p.Doctors.Any(pd => pd.DoctorId == doctorId))
        {
            if (!string.IsNullOrEmpty(patientSpec.Search))
            {
                Criteira = p => p.Doctors.Any(pd => pd.DoctorId == doctorId) &&
                                p.Name.ToLower().Contains(patientSpec.Search);
            }
        }
    }

}
