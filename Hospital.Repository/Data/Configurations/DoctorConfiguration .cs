using Hospital.Core.Enums;
using Hospital.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Password).IsRequired(); 
            builder.Property(d => d.PhoneNumber).HasMaxLength(20);
            builder.Property(d => d.Email).HasMaxLength(100);
            builder.Property(d => d.Address).HasMaxLength(255);
            builder.Property(d => d.Salary).HasColumnType("decimal(18,2)");
            builder.Property(d => d.Age).IsRequired();
            builder.Property(d => d.PictureUrl).HasMaxLength(200);
            builder.Property(d => d.Rate).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(d => d.Major)
                   .HasConversion(major => major.ToString(), major => (Major)Enum.Parse(typeof(Major), major));
            builder.Property(d => d.Position)
                   .HasConversion(position => position.ToString(), position => (Position)Enum.Parse(typeof(Position), position));
            // Relationships
            builder.HasMany(d => d.Appointments)
                   .WithOne(a => a.Doctor)
                   .HasForeignKey(a => a.DoctorId);
                   

            builder.HasMany(d => d.Patients)
                   .WithOne(pd => pd.Doctor)
                   .HasForeignKey(pd => pd.DoctorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.medicalHistories)
                 .WithOne(mh => mh.Doctor)
                 .HasForeignKey(mh => mh.DoctorId);

            builder.HasMany(p => p.Bills)
                 .WithOne(mh => mh.Doctor)
                 .HasForeignKey(mh => mh.DoctorId);
            
        }
    }
}
