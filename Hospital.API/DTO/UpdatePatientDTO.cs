using Hospital.Core.Enums;

namespace Hospital.API.DTO
{
    public class UpdatePatientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public BloodType BloodType { get; set; }
        public int Age { get; set; }
    }
}
