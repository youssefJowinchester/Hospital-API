using Hospital.Core.Models.Domain;
using Hospital.Core.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Data.Contexts
{
    public class HospitalDbContext : IdentityDbContext<ApplicationUser>
    {

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<HospitalClass> Hospitals { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Patients_Doctors> Patients_Doctors { get; set; }
        public DbSet<Patients_Nurses> Patients_Nurses { get; set; }
    }
}
