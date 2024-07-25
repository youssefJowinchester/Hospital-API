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
    public class MedicalHistoryConfiguration : IEntityTypeConfiguration<MedicalHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalHistory> builder)
        {
            builder.HasKey(mh => mh.Id);

            builder.Property(mh => mh.History)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(mh => mh.Patient)
                .WithMany(p => p.MedicalHistories)
                .HasForeignKey(mh => mh.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mh => mh.Doctor)
             .WithMany(p => p.medicalHistories)
             .HasForeignKey(mh => mh.DoctorId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
