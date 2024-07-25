using AutoMapper;
using Hospital.API.DTO;
using Hospital.Core.Models.Domain;

namespace Hospital.API.Helpers.PictureUrlResol
{
    public class PatientPictureUrlResolver : IValueResolver<Patient, PatienWithDoctorDTO, string>
    {
        private readonly IConfiguration _configuration;

        public PatientPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Patient source, PatienWithDoctorDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["Base"]}/{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
