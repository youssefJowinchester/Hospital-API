using Hospital.Core.Models.Domain;
using Hospital.Core.Specifications.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Specifications.ModelsSpecifications.DataSpe
{
    public class BillSpecifications : BaseSpecifications<Bill>
    {
        public BillSpecifications() : base()
        {
            Includes.Add(D => D.Patient);
        }

        public BillSpecifications(int id) : base(D => D.Id == id)
        {
            Includes.Add(D => D.Patient);
        }
    }
}
