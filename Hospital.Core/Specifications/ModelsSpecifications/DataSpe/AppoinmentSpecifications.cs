using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.DataSpe
{
    public class AppoinmentSpecifications : BaseSpecifications<Appointment>
    {
        public AppoinmentSpecifications() : base()
        {
            Includes.Add(A => A.Patient);
            Includes.Add(A => A.Doctor);
        }

        public AppoinmentSpecifications(int id) : base(D => D.Id == id)
        {
            Includes.Add(D => D.Patient);
            Includes.Add(A => A.Doctor);
        }
    }
}
