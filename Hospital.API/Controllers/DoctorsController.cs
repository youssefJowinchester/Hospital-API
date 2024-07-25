using AutoMapper;
using Hospital.API.DTO;
using Hospital.API.Errors;
using Hospital.API.Helpers;
using Hospital.Core.Models.Domain;
using Hospital.Core.Repositories.Interfaces;
using Hospital.Core.Specifications.ModelsSpecifications;
using Hospital.Core.Specifications.ModelsSpecifications.DoctorSpe;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    public class DoctorsController : BaseApiController
    {


        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DoctorsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region get patient list
        [HttpGet("patient")]
        public async Task<ActionResult<Pagination<PatienWithDoctorDTO>>> GetPatientsByDoctorId(int doctorId, [FromQuery] SpecParams patientSpec)
        {
            var spec = new PatientWithSpecifications(doctorId, patientSpec);
            var patients = await _unitOfWork.Repository<Patient>().GetAllWithSpecAsync(spec);

            var countSpec = new PatientwithCountSpecifications(doctorId, patientSpec);
            int count = await _unitOfWork.Repository<Patient>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatienWithDoctorDTO>>(patients);

            return Ok(new Pagination<PatienWithDoctorDTO>(patientSpec.PageSize, patientSpec.PageIndex, count, data));


        }
        #endregion

        #region get nurse list
        [HttpGet("nurse")]
        public async Task<ActionResult<Pagination<NurseWithDoctorDto>>> GetNursesByDoctorId(int doctorId, [FromQuery] SpecParams nurseSpec)
        {
            var spec = new NurseWithtSpecifications(doctorId, nurseSpec);
            var nurses = await _unitOfWork.Repository<Nurse>().GetAllWithSpecAsync(spec);

            var countSpec = new NursewithCountSpecifications(doctorId, nurseSpec);
            int count = await _unitOfWork.Repository<Nurse>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<Nurse>, IEnumerable<NurseWithDoctorDto>>(nurses);

            return Ok(new Pagination<NurseWithDoctorDto>(nurseSpec.PageSize, nurseSpec.PageIndex, count, data));

        }
        #endregion

        #region Update Password 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("update")]
        public async Task<ActionResult> UpdateDoctor(int DoctorId, [FromBody] UpdatePasswordWithDoctor updateDTO)
        {
            var DoctorRepository = _unitOfWork.Repository<Doctor>();
            var doctor = await DoctorRepository.GetByIdAsync(DoctorId);

            if (doctor == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _mapper.Map(updateDTO, doctor);
            DoctorRepository.Update(doctor);
            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return NoContent();
            }

            throw new Exception($"Updating patient {DoctorId} failed on save");
        }
        #endregion

    }
}
