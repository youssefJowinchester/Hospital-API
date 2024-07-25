using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.HomeSpe
{
    public class DoctorWithtSpecifications : BaseSpecifications<Doctor>
    {

        public DoctorWithtSpecifications(SpecParams doctorSpec)
            : base(P => string.IsNullOrEmpty(doctorSpec.Search) || P.Name.ToLower().Contains(doctorSpec.Search))
        {
            Includes.Add(D => D.Appointments);

            if (!string.IsNullOrEmpty(doctorSpec.sort))
            {
                switch (doctorSpec.sort)
                {
                    case "rate":
                        AddorderBy(P => P.Rate);
                        break;

                    case "rateDesc":
                        AddorderByDesc(P => P.Rate);
                        break;

                    default:
                        AddorderBy(P => P.Name);
                        break;
                }
            }
            else
            {
                AddorderBy(P => P.Name);
            }

            // PageSize - PageIndex
            // Total = 18 
            // PageSize = 5 * 3
            // pageIndex = 4
            ApplyPagiantion(doctorSpec.PageSize * (doctorSpec.PageIndex - 1), doctorSpec.PageSize);
        }

        public DoctorWithtSpecifications(int id) : base(D => D.Id == id)
        {
            Includes.Add(D => D.Appointments);
        }
    }
}
