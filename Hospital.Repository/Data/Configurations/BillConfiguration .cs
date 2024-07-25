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
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(b => b.Id);
           

            builder.Property(b => b.Amount).HasColumnType("decimal(18,2)").IsRequired();

            // Relationships
            builder.HasOne(b => b.Patient)
                   .WithMany(p => p.Bills)
                   .HasForeignKey(b => b.PatientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Doctor)
              .WithMany(p => p.Bills)
              .HasForeignKey(b => b.DoctorId)
              .OnDelete(DeleteBehavior.SetNull);
            // Additional configurations as needed
        }
    }
}
