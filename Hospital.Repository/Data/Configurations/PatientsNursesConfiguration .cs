using Hospital.Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Data.Configurations
{
    public class PatientsNursesConfiguration : IEntityTypeConfiguration<Patients_Nurses>
    {
        public void Configure(EntityTypeBuilder<Patients_Nurses> builder)
        {
            // Define composite primary key
            builder.HasKey(pn => new { pn.PatientId, pn.NurseId });

            // Configure Patient and Nurse relationships
            builder.HasOne(pn => pn.Patient)
                .WithMany(p => p.Nurses)
                .HasForeignKey(pn => pn.PatientId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade as per your requirement

            builder.HasOne(pn => pn.Nurse)
                .WithMany(n => n.Patients)
                .HasForeignKey(pn => pn.NurseId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade as per your requirement
        }
    }
}
