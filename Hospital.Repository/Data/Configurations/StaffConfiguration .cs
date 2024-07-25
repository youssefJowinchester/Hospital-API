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
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(s => s.Id);
           

            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Password).IsRequired(); // Assuming password is required
            builder.Property(s => s.PhoneNumber).HasMaxLength(20);
            builder.Property(s => s.Email).HasMaxLength(100);
            builder.Property(s => s.Address).HasMaxLength(255);
            builder.Property(s => s.Salary).HasColumnType("decimal(18,2)");
            builder.Property(s => s.Age);
            builder.Property(d => d.PictureUrl).HasMaxLength(200);
            builder.Property(s => s.Role).IsRequired().HasMaxLength(50);

            // Define enumeration mapping for JobTitle (assuming it's an enum)
            builder.Property(s => s.JobTitle)
                  .HasConversion(title => title.ToString(), title => (JobTitle)Enum.Parse(typeof(JobTitle), title)); // Store enum as string in database

            // Additional configurations as needed
        }
    }
}
