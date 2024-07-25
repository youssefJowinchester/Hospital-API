using Hospital.Core.Enums;
using Hospital.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital.Repository.Data.Contexts
{
    public static class HospitalDbContextSeed
    {
        public static async Task SeedAsync(HospitalDbContext _context)
        {


            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };


            if (_context.Doctors.Count() == 0)
            {
                // 1. Read Data From Json File....
                var DoctorData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Doctor.json");
                // 2. Convert Json String To The Needed Type...
                var Doctors = JsonSerializer.Deserialize<List<Doctor>>(DoctorData,options);

                if (Doctors?.Count() > 0)
                {
                    foreach (var doctor in Doctors)
                    {
                        _context.Set<Doctor>().Add(doctor);
                    }
                    await _context.SaveChangesAsync();
                }
            }

            // =============================================================

            // 2. Nurses
            if (_context.Nurses.Count() == 0)
            {
                // 1. Read Data From Json File....
                var NurseData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Nurse.json");
                // 2. Convert Json String To The Needed Type...
                var Nurses = JsonSerializer.Deserialize<List<Nurse>>(NurseData);

                if (Nurses?.Count() > 0)
                {
                    foreach (var nurse in Nurses)
                    {
                        _context.Set<Nurse>().Add(nurse);
                    }
                    await _context.SaveChangesAsync();
                }
            }

            // =============================================================

            //3.Patients
            if (_context.Patients.Count() == 0)
            {
                // 1. Read Data From Json File....
                var PatientData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Patient.json");
                // 2. Convert Json String To The Needed Type...
                var Patients = JsonSerializer.Deserialize<List<Patient>>(PatientData);

                if (Patients?.Count() > 0)
                {
                    foreach (var patient in Patients)
                    {
                        _context.Set<Patient>().Add(patient);
                    }
                    await _context.SaveChangesAsync();
                }
            }



            // =============================================================

           // 4.Bills
            if (_context.Bills.Count() == 0)
            {
                // 1. Read Data From Json File....
                var BillData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Bill.json");
                // 2. Convert Json String To The Needed Type...
                var Bills = JsonSerializer.Deserialize<List<Bill>>(BillData);

                if (Bills?.Count() > 0)
                {
                    foreach (var bill in Bills)
                    {
                        _context.Set<Bill>().Add(bill);
                    }
                    await _context.SaveChangesAsync();
                }
            }


            // =============================================================

            //5.Appointments
            if (_context.Appointments.Count() == 0)
            {
                // 1. Read Data From Json File....
                var AppointmentData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Appointment.json");
                // 2. Convert Json String To The Needed Type...
                var Appointments = JsonSerializer.Deserialize<List<Appointment>>(AppointmentData);

                if (Appointments?.Count() > 0)
                {
                    foreach (var appointment in Appointments)
                    {
                        _context.Set<Appointment>().Add(appointment);
                    }
                    await _context.SaveChangesAsync();
                }
            }


            // =============================================================

            // 6. Hospitals
            if (_context.Hospitals.Count() == 0)
            {
                // 1. Read Data From Json File....
                var HospitalData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Hospital.json");
                // 2. Convert Json String To The Needed Type...
                var Hospitals = JsonSerializer.Deserialize<List<HospitalClass>>(HospitalData);

                if (Hospitals?.Count() > 0)
                {
                    foreach (var hospital in Hospitals)
                    {
                        _context.Set<HospitalClass>().Add(hospital);
                    }
                    await _context.SaveChangesAsync();
                }
            }


            // =============================================================

            // 7. Staff
            if (_context.Staff.Count() == 0)
            {
                // 1. Read Data From Json File....
                var StaffData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Staff.json");
                // 2. Convert Json String To The Needed Type...
                var Staffs = JsonSerializer.Deserialize<List<Staff>>(StaffData,options);

                if (Staffs?.Count() > 0)
                {
                    foreach (var staff in Staffs)
                    {
                        _context.Set<Staff>().Add(staff);
                    }
                    await _context.SaveChangesAsync();
                }
            }


            // =============================================================

            // 8. MedicalHistory
            if (_context.MedicalHistories.Count() == 0)
            {
                // 1. Read Data From Json File....
                var MedicalHistoryData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/MedicalHistory.json");
                // 2. Convert Json String To The Needed Type...
                var MedicalHistorys = JsonSerializer.Deserialize<List<MedicalHistory>>(MedicalHistoryData);

                if (MedicalHistorys?.Count() > 0)
                {
                    foreach (var medicalHistory in MedicalHistorys)
                    {
                        _context.Set<MedicalHistory>().Add(medicalHistory);
                    }
                    await _context.SaveChangesAsync();
                }
            }


            // =============================================================

            // 9. Patients_Doctors
            if (_context.Patients_Doctors.Count() == 0)
            {
                // 1. Read Data From Json File....
                var Patients_DoctorsData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Patients_Doctors.json");
                // 2. Convert Json String To The Needed Type...
                var patients_doctors = JsonSerializer.Deserialize<List<Patients_Doctors>>(Patients_DoctorsData);

                if (patients_doctors?.Count() > 0)
                {
                    foreach (var patient_doctor in patients_doctors)
                    {
                        _context.Set<Patients_Doctors>().Add(patient_doctor);
                    }
                    await _context.SaveChangesAsync();
                }
            }


            //// =============================================================

            //// 10. Patients_Nurses
            if (_context.Patients_Nurses.Count() == 0)
            {
                // 1. Read Data From Json File....
                var Patients_NursesData = File.ReadAllText("../Hospital.Repository/Data/DataSeed/Patients_Nurses.json");
                // 2. Convert Json String To The Needed Type...
                var patients_nurses = JsonSerializer.Deserialize<List<Patients_Nurses>>(Patients_NursesData);

                if (patients_nurses?.Count() > 0)
                {
                    foreach (var patient_nurse in patients_nurses)
                    {
                        _context.Set<Patients_Nurses>().Add(patient_nurse);
                    }
                    await _context.SaveChangesAsync();
                }
            }

        }


    }


}
