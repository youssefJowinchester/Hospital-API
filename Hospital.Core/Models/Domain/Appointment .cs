using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Core.Models.Domain
{
    public class Appointment : BaseModel
    {
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public  Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public  Doctor Doctor { get; set; }


    }
}
