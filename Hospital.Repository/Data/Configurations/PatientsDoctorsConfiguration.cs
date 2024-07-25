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
    public class PatientsDoctorsConfiguration : IEntityTypeConfiguration<Patients_Doctors>
    {
        public void Configure(EntityTypeBuilder<Patients_Doctors> builder)
        {
            // Define composite primary key
            builder.HasKey(pd => new { pd.PatientId, pd.DoctorId });

            // Configure Patient and Doctor relationships
            builder.HasOne(pd => pd.Patient)
                .WithMany(p => p.Doctors)
                .HasForeignKey(pd => pd.PatientId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade as per your requirement

            builder.HasOne(pd => pd.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(pd => pd.DoctorId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade as per your requirement
        }
    }
}
