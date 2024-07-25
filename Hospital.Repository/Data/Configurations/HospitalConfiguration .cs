using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core.Models.Domain;

namespace Hospital.Repository.Data.Configurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<HospitalClass>
    {
        public void Configure(EntityTypeBuilder<HospitalClass> builder)
        {
            builder.HasKey(h => h.Id);
          
            builder.Property(h => h.Name).IsRequired().HasMaxLength(100);
            builder.Property(h => h.PhoneNumber).HasMaxLength(20);
            builder.Property(h => h.Address).HasMaxLength(255);
            builder.Property(h => h.Room).IsRequired();
            builder.Property(h => h.Email).HasMaxLength(255);
   
            // Additional configurations as needed
        }
    }
}
