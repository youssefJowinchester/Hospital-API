using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.PatientSpe
{
    public class NurseWithtPatientSpecifications : BaseSpecifications<Nurse>
    {
        public NurseWithtPatientSpecifications(int patientId, SpecParams nurseSpec)
                     : base(p => p.Patients.Any(d => d.PatientId == patientId) &&
                     (string.IsNullOrEmpty(nurseSpec.Search) || p.Name.ToLower().Contains(nurseSpec.Search)))
        {
            Includes.Add(E => E.Doctor);
            Includes.Add(E => E.Patients);

            if (!string.IsNullOrEmpty(nurseSpec.sort))
            {
                switch (nurseSpec.sort)
                {
                    case "rate":
                        AddorderBy(p => p.Rate);
                        break;
                    case "rateDesc":
                        AddorderByDesc(p => p.Rate);
                        break;
                    default:
                        AddorderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddorderBy(p => p.Name);
            }

            ApplyPagiantion(nurseSpec.PageSize * (nurseSpec.PageIndex - 1), nurseSpec.PageSize);
        }


    }
}
