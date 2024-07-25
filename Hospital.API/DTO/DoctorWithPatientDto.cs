namespace Hospital.API.DTO
{
    public class DoctorWithPatientDto
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public decimal Rate { get; set; }
        public string Major { get; set; }
        public string Position { get; set; }
    }
}
