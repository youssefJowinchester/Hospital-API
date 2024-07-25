using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.NurseSpe
{
    public class PatientWithNurseSpecifications : BaseSpecifications<Patient>
    {

        public PatientWithNurseSpecifications(int id) : base(D => D.Id == id)
        {
            Includes.Add(p => p.Appointments);
            Includes.Add(p => p.Doctors);
            Includes.Add(p => p.MedicalHistories);
        }

        public PatientWithNurseSpecifications(SpecParams patientSpec)
            : base(p => string.IsNullOrEmpty(patientSpec.Search) || p.Name.ToLower().Contains(patientSpec.Search))
        {
            Includes.Add(p => p.Appointments);
            Includes.Add(p => p.Doctors);
            Includes.Add(p => p.MedicalHistories);

            if (!string.IsNullOrEmpty(patientSpec.sort))
            {
                switch (patientSpec.sort)
                {
                    case "age":
                        AddorderBy(p => p.Age);
                        break;
                    case "ageDesc":
                        AddorderByDesc(p => p.Age);
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

            ApplyPagiantion(patientSpec.PageSize * (patientSpec.PageIndex - 1), patientSpec.PageSize);
        }

        public PatientWithNurseSpecifications(int nurseId, SpecParams patientSpec)
        : base(p => p.Nurses.Any(d => d.NurseId == nurseId) &&
                    (string.IsNullOrEmpty(patientSpec.Search) || p.Name.ToLower().Contains(patientSpec.Search)))
        {
            Includes.Add(p => p.Appointments);
            Includes.Add(p => p.Doctors);
            Includes.Add(p => p.MedicalHistories);
            Includes.Add(p => p.Nurses);

            if (!string.IsNullOrEmpty(patientSpec.sort))
            {
                switch (patientSpec.sort)
                {
                    case "age":
                        AddorderBy(p => p.Age);
                        break;
                    case "ageDesc":
                        AddorderByDesc(p => p.Age);
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

            ApplyPagiantion(patientSpec.PageSize * (patientSpec.PageIndex - 1), patientSpec.PageSize);
        }




    }
}
