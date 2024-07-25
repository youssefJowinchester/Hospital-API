using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.DoctorSpe
{
    public class PatientWithSpecifications : BaseSpecifications<Patient>
    {

        public PatientWithSpecifications(SpecParams patientSpec)
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

        public PatientWithSpecifications(int id) : base(D => D.Id == id)
        {
            Includes.Add(p => p.Appointments);
            Includes.Add(p => p.Doctors);
            Includes.Add(p => p.MedicalHistories);
        }



        public PatientWithSpecifications(int doctorId, SpecParams patientSpec)
        : base(p => p.Doctors.Any(d => d.DoctorId == doctorId) &&
                    (string.IsNullOrEmpty(patientSpec.Search) || p.Name.ToLower().Contains(patientSpec.Search)))
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




    }

}
