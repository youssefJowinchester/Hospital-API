using AutoMapper;
using Hospital.API.DTO;
using Hospital.API.Errors;
using Hospital.API.Helpers;
using Hospital.Core.Models.Domain;
using Hospital.Core.Repositories.Interfaces;
using Hospital.Core.Specifications.ModelsSpecifications;
using Hospital.Core.Specifications.ModelsSpecifications.NurseSpe;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    public class NursesController : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public NursesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region get doctor list
        [HttpGet("doctor")]
        public async Task<ActionResult<IEnumerable<DocWithNurseDTO>>> GetDoctors(int nurseId, [FromQuery] SpecParams doctorSpec)
        {
            var spec = new DoctorWithNurseSpecifications(nurseId, doctorSpec);
            var doctors = await _unitOfWork.Repository<Doctor>().GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DocWithNurseDTO>>(doctors);
            return Ok(new Pagination<DocWithNurseDTO>(doctorSpec.PageSize, doctorSpec.PageIndex, 1, data));
        }
        #endregion

        #region get patient list
        [HttpGet("patient")]
        public async Task<ActionResult<Pagination<PatienWithDoctorDTO>>> GetPatientsByNurseId(int nurseId, [FromQuery] SpecParams patientSpec)
        {
            var spec = new PatientWithNurseSpecifications(nurseId, patientSpec);
            var patients = await _unitOfWork.Repository<Patient>().GetAllWithSpecAsync(spec);

            var countSpec = new PatientwithNurseCountSpecifications(nurseId, patientSpec);
            int count = await _unitOfWork.Repository<Patient>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatienWithDoctorDTO>>(patients);

            return Ok(new Pagination<PatienWithDoctorDTO>(patientSpec.PageSize, patientSpec.PageIndex, count, data));


        }
        #endregion

        #region Update Password Nurse
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("updateNurse")]
        public async Task<ActionResult> UpdateNurse(int nurseId, [FromBody] UpdatePasswordWithNurse nurse_DTO)
        {
            var NurseRepository = _unitOfWork.Repository<Nurse>();
            var nurse = await NurseRepository.GetByIdAsync(nurseId);

            if (nurse == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _mapper.Map(nurse_DTO, nurse);
            NurseRepository.Update(nurse);
            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return NoContent();
            }

            throw new Exception($"Updating patient {nurseId} failed on save");
        }
        #endregion
    }
}
