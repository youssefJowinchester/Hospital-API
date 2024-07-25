using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.DoctorSpe
{
    public class NursewithCountSpecifications : BaseSpecifications<Nurse>
    {
        public NursewithCountSpecifications(int doctorId, SpecParams NurseSpec) : base(n => n.DoctorId == doctorId)
        {
            if (!string.IsNullOrEmpty(NurseSpec.Search))
            {
                Criteira = p => p.DoctorId == doctorId && p.Name.ToLower().Contains(NurseSpec.Search);
            }
        }
    }
}

