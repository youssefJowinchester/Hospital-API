using AutoMapper;
using Hospital.API.DTO;
using Hospital.Core.Models.Domain;

namespace Hospital.API.Helpers.PictureUrlResol
{
    public class DoctorPictureUrlResolver : IValueResolver<Doctor, DocHomeDto, string>
    {

        private readonly IConfiguration _configuration;

        public DoctorPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Doctor source, DocHomeDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["Base"]}/{source.PictureUrl}";
            }
            return string.Empty;
        }
    }

}
