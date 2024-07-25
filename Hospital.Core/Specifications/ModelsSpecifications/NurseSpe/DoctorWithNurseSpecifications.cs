using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.NurseSpe
{
    public class DoctorWithNurseSpecifications : BaseSpecifications<Doctor>
    {
        public DoctorWithNurseSpecifications(int nurseId, SpecParams doctorSpec) : base(p => p.Nurses.Any(d => d.Id == nurseId) &&
                    (string.IsNullOrEmpty(doctorSpec.Search) || p.Name.ToLower().Contains(doctorSpec.Search)))
        {
            Includes.Add(d => d.Nurses); // Include nurses for doctor
            Includes.Add(d => d.Appointments); // Include appointments for doctor


            if (!string.IsNullOrEmpty(doctorSpec.sort))
            {
                switch (doctorSpec.sort)
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

            ApplyPagiantion(doctorSpec.PageSize * (doctorSpec.PageIndex - 1), doctorSpec.PageSize);

        }

        public DoctorWithNurseSpecifications(SpecParams doctorSpec)
           : base(p => string.IsNullOrEmpty(doctorSpec.Search) || p.Name.ToLower().Contains(doctorSpec.Search))
        {
            Includes.Add(p => p.Appointments);
            Includes.Add(p => p.Nurses);


            if (!string.IsNullOrEmpty(doctorSpec.sort))
            {
                switch (doctorSpec.sort)
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

            ApplyPagiantion(doctorSpec.PageSize * (doctorSpec.PageIndex - 1), doctorSpec.PageSize);
        }

        public DoctorWithNurseSpecifications(int id) : base(D => D.Id == id)
        {
            Includes.Add(p => p.Appointments);
            Includes.Add(p => p.Nurses);
        }
    }
}
