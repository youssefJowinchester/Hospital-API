using Hospital.Core.Enums;

namespace Hospital.API.DTO
{
    public class DocHomeDto
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }

        public decimal Rate { get; set; }
        public string Major { get; set; }
        public string Position { get; set; }
    }
}
