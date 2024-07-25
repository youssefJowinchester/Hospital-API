using Hospital.Core.Models.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Enums;

namespace Hospital.Repository.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
           
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Password).IsRequired(); // Assuming password is required
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(p => p.Address).HasMaxLength(255);
            builder.Property(p => p.Age).IsRequired();
            builder.Property(d => d.PictureUrl).HasMaxLength(200);
            builder.Property(p => p.BloodType)
                   .HasConversion(blood => blood.ToString(), blood => (BloodType)Enum.Parse(typeof(BloodType), blood));

            // Relationships
            builder.HasMany(p => p.Appointments)
                   .WithOne(a => a.Patient)
                   .HasForeignKey(a => a.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Doctors)
                   .WithOne(pd => pd.Patient)
                   .HasForeignKey(pd => pd.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Nurses)
                   .WithOne(pn => pn.Patient)
                   .HasForeignKey(pn => pn.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.MedicalHistories)
                   .WithOne(mh => mh.Patient)
                   .HasForeignKey(mh => mh.PatientId);
            // Additional configurations as needed
        }
    }
}
