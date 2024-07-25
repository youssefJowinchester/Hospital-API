using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Enums;
using Hospital.Core.Models.Identity;

namespace Hospital.Core.Models.Domain
{
    public class Staff : ContactInfo
    {
        public string Role { get; set; }
        public JobTitle  JobTitle { get; set; }
        public decimal Salary { get; set; }
    }
}
