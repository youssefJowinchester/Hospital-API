using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.DoctorSpe
{
    public class NurseWithtSpecifications : BaseSpecifications<Nurse>
    {

        public NurseWithtSpecifications(SpecParams nurseSpec)
            : base(p => string.IsNullOrEmpty(nurseSpec.Search) || p.Name.ToLower().Contains(nurseSpec.Search))
        {
            Includes.Add(E => E.Doctor);
            Includes.Add(E => E.Patients);

            if (!string.IsNullOrEmpty(nurseSpec.sort))
            {
                switch (nurseSpec.sort)
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

            ApplyPagiantion(nurseSpec.PageSize * (nurseSpec.PageIndex - 1), nurseSpec.PageSize);
        }


        public NurseWithtSpecifications(int doctorId, SpecParams nurseSpec)
        : base(p => p.DoctorId == doctorId &&
                    (string.IsNullOrEmpty(nurseSpec.Search) || p.Name.ToLower().Contains(nurseSpec.Search)))
        {
            Includes.Add(E => E.Doctor);
            Includes.Add(E => E.Patients);

            if (!string.IsNullOrEmpty(nurseSpec.sort))
            {
                switch (nurseSpec.sort)
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

            ApplyPagiantion(nurseSpec.PageSize * (nurseSpec.PageIndex - 1), nurseSpec.PageSize);
        }


        public NurseWithtSpecifications() : base()
        {
            Includes.Add(E => E.Doctor);
            Includes.Add(E => E.Patients);
        }

        public NurseWithtSpecifications(int id) : base(E => E.Id == id)
        {
            Includes.Add(E => E.Doctor);
            Includes.Add(E => E.Patients);
        }

    }
}
