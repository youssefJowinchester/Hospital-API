using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.NurseSpe
{
    public class PatientwithNurseCountSpecifications : BaseSpecifications<Patient>
    {
        public PatientwithNurseCountSpecifications(int nurseId, SpecParams patientSpec) : base(p => p.Nurses.Any(pd => pd.NurseId == nurseId))
        {
            if (!string.IsNullOrEmpty(patientSpec.Search))
            {
                Criteira = p => p.Nurses.Any(pd => pd.NurseId == nurseId) &&
                                p.Name.ToLower().Contains(patientSpec.Search);
            }
        }
    }
}
