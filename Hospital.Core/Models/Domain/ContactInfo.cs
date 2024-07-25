using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Models.Domain
{
    public class ContactInfo : BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
}
