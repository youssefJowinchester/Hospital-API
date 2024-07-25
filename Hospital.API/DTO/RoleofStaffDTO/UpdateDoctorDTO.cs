using Hospital.Core.Enums;

namespace Hospital.API.DTO.RoleofStaffDTO
{
    public class UpdateDoctorDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email  { get; set; }
        public string PictureUrl { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public string position { get; set; }
        public decimal Rate { get; set; }
    }
}
