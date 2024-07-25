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
    public class NurseConfiguration : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.HasKey(n => n.Id);
          
            builder.Property(n => n.Name).IsRequired().HasMaxLength(100);
            builder.Property(n => n.Password).IsRequired(); // Assuming password is required
            builder.Property(n => n.PhoneNumber).HasMaxLength(20);
            builder.Property(n => n.Email).HasMaxLength(100);
            builder.Property(n => n.Address).HasMaxLength(255);
            builder.Property(n => n.Salary).HasColumnType("decimal(18,2)");
            builder.Property(n => n.Age).IsRequired();
            builder.Property(d => d.PictureUrl).HasMaxLength(200);
            builder.Property(n => n.Rate).HasColumnType("decimal(18,2)").IsRequired();

            // Relationship with Doctor
            builder.HasOne(n => n.Doctor)
                   .WithMany(d => d.Nurses)
                   .HasForeignKey(n => n.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relationship with Patients_Nurses
            builder.HasMany(n => n.Patients)
                   .WithOne(pn => pn.Nurse)
                   .HasForeignKey(pn => pn.NurseId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Additional configurations as needed
        }
    }
}
