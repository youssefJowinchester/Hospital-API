using AutoMapper;
using Hospital.API.DTO;
using Hospital.Core.Models.Domain;

namespace Hospital.API.Helpers.PictureUrlResol
{
    public class NurseWithPatientPictureUrlResolver : IValueResolver<Nurse, NurseWithPatientDto, string>
    {

        private readonly IConfiguration _configuration;

        public NurseWithPatientPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Nurse source, NurseWithPatientDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["Base"]}/{source.PictureUrl}";
            }
            return string.Empty;
        }

    }
}
