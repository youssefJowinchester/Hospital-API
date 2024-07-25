using Hospital.Core.Enums;

namespace Hospital.API.DTO
{
    public class PatienWithDoctorDTO
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public int Age { get; set; }
        public string BloodType { get; set; }
        public DateTime Date { get; set; }
        public string History { get; set; }
    }
}
