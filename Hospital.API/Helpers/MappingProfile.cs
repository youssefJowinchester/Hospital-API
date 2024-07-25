using AutoMapper;
using Hospital.API.DTO;
using Hospital.API.DTO.RoleofStaffDTO;
using Hospital.API.Helpers.PictureUrlResol;
using Hospital.Core.Models.Domain;

namespace Hospital.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Data Controller
            CreateMap<Bill, BillDTO>().ForMember(B => B.PatientName, BD => BD.MapFrom(S => S.Patient.Name));
            CreateMap<Appointment, AppoinmentDTO>().ForMember(B => B.PatientName, BD => BD.MapFrom(S => S.Patient.Name))
                                                   .ForMember(B => B.DoctorName, BD => BD.MapFrom(S => S.Doctor.Name));
            #endregion

            #region Hospitals , Patient Controller

            CreateMap<Doctor, DocHomeDto>().ForMember(D => D.PictureUrl, O => O.MapFrom<DoctorPictureUrlResolver>());
            
            #endregion

            #region Patient With Doctor and Nurse Controller
            CreateMap<Patient, PatienWithDoctorDTO>()
           .ForMember(pdto => pdto.Name, opt => opt.MapFrom(p => p.Name))
           .ForMember(pdto => pdto.PictureUrl, opt => opt.MapFrom<PatientPictureUrlResolver>())
           .ForMember(pdto => pdto.Age, opt => opt.MapFrom(p => p.Age))
           .ForMember(pdto => pdto.BloodType, opt => opt.MapFrom(p => p.BloodType.ToString())) // Assuming BloodType is an enum
           .ForMember(pdto => pdto.Date, opt => opt.MapFrom(p => p.Appointments.OrderByDescending(a => a.Date).FirstOrDefault().Date))
           .ForMember(pdto => pdto.History, opt => opt.MapFrom(p => p.MedicalHistories.OrderByDescending(mh => mh.Id).FirstOrDefault().History));
            CreateMap<Nurse, NurseWithDoctorDto>().ForMember(D => D.PictureUrl, O => O.MapFrom<NursePictureUrlResolver>());
            CreateMap<UpdatePasswordWithDoctor, Doctor>().ReverseMap();

            
          

            #endregion

            #region Nurse Controller

            CreateMap<Doctor, DocWithNurseDTO>().ForMember(D => D.PictureUrl, O => O.MapFrom<NurseWithDoctorPictureUrlResolver>());

            CreateMap<UpdatePasswordWithNurse, Nurse>().ReverseMap();

            #endregion

            #region Patient Controller

            CreateMap<Doctor, DoctorWithPatientDto>()
           .ForMember(pdto => pdto.Name, opt => opt.MapFrom(p => p.Name))
           .ForMember(pdto => pdto.PictureUrl, opt => opt.MapFrom<DoctorWithPatientPictureUrlResolver>())
           .ForMember(pdto => pdto.Age, opt => opt.MapFrom(p => p.Age))
           .ForMember(pdto => pdto.Major, opt => opt.MapFrom(p => p.Major.ToString()))
           .ForMember(pdto => pdto.Position, opt => opt.MapFrom(p => p.Position.ToString()))
           .ForMember(pdto => pdto.Date, opt => opt.MapFrom(p => p.Appointments.OrderByDescending(a => a.Date).FirstOrDefault().Date));


            CreateMap<Nurse, NurseWithPatientDto>().ForMember(B => B.DoctorName, BD => BD.MapFrom(S => S.Doctor.Name))
                .ForMember(D => D.PictureUrl, O => O.MapFrom<NurseWithPatientPictureUrlResolver>());


            CreateMap<Bill, BillWithPatientDTO>().ForMember(B => B.DoctorName, BD => BD.MapFrom(S => S.Doctor.Name));

            CreateMap<Appointment, AppoinmentWithPatientDTO>().ForMember(B => B.DoctorName, BD => BD.MapFrom(S => S.Doctor.Name));

            CreateMap<MedicalHistory, MedicalWithPatientDTO>().ForMember(B => B.DoctorName, BD => BD.MapFrom(S => S.Doctor.Name));

            CreateMap<UpdatePatientDTO, Patient>();

            #endregion

            #region HR
            CreateMap<AddDctorDTO, Doctor>().ReverseMap();
            CreateMap<UpdateDoctorDTO, Doctor>().ReverseMap();


            CreateMap<AddNurseDTO, Nurse>().ReverseMap();
            CreateMap<UpdateNurseDTO, Nurse>().ReverseMap();


            CreateMap<AddStaffDTO, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();
            CreateMap<UpdatePasswordWithStaff, Staff>().ReverseMap();

            #endregion


            #region Management
            CreateMap<Appoinment_DTO, Appointment>().ReverseMap();
            CreateMap<Bill_DTO, Bill>().ReverseMap();
            #endregion

        }
    }
}
