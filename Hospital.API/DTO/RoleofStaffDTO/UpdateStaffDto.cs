using Hospital.Core.Enums;

namespace Hospital.API.DTO.RoleofStaffDTO
{
    public class UpdateStaffDto
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string PictureUrl { get; set; }
        public string  PhoneNumber { get; set; }

    }
}
