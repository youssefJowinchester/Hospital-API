using Hospital.Core.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.DTO
{
    public class AppoinmentDTO
    {
        public DateTime Date { get; set; }

        public int? PatientId { get; set; }
        public string PatientName { get; set; }

        
        public int? DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
