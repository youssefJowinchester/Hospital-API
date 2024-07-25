using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.PatientSpe
{
    public class AppoinmentCountWithPatientSpecifications : BaseSpecifications<Appointment>
    {

        public AppoinmentCountWithPatientSpecifications(BASpecParams BSpec) : base(P =>

             (!BSpec.PatientId.HasValue || P.PatientId == BSpec.PatientId.Value)
             &&
             (!BSpec.DoctorId.HasValue || P.DoctorId == BSpec.DoctorId.Value))
         
        {

        }

    }
}
