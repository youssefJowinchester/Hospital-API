using AutoMapper;
using Hospital.API.DTO;
using Hospital.API.Errors;
using Hospital.API.Helpers;
using Hospital.Core.Models.Domain;
using Hospital.Core.Repositories.Interfaces;
using Hospital.Core.Specifications.ModelsSpecifications;
using Hospital.Core.Specifications.ModelsSpecifications.HomeSpe;
using Hospital.Core.Specifications.ModelsSpecifications.PatientSpe;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    public class PatientsController : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PatientsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region get doctor list
        [HttpGet("doctors")]
        public async Task<ActionResult<IEnumerable<DocHomeDto>>> GetDoctors([FromQuery] SpecParams doctorSpec)
        {
            var spec = new DoctorWithPatientSpecifications(doctorSpec);
            var doctors = await _unitOfWork.Repository<Doctor>().GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DocHomeDto>>(doctors);

            var countspec = new DoctorwithCountSpecifications();
            int count = await _unitOfWork.Repository<Doctor>().GetCountAsync(countspec);

            return Ok(new Pagination<DocHomeDto>(doctorSpec.PageSize, doctorSpec.PageIndex, count, data));
        }
        #endregion

        #region get doctor by Patient ID list
        [HttpGet("doctor")]
        public async Task<ActionResult<Pagination<DoctorWithPatientDto>>> GetByDoctorsPatientId(int patientId, [FromQuery] SpecParams doctorSpec)
        {
            var spec = new DoctorWithPatientSpecifications(patientId, doctorSpec);
            var doctors = await _unitOfWork.Repository<Doctor>().GetAllWithSpecAsync(spec);

            var countSpec = new DoctorWithPatientCountSpecifications(patientId, doctorSpec);
            int count = await _unitOfWork.Repository<Doctor>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorWithPatientDto>>(doctors);

            return Ok(new Pagination<DoctorWithPatientDto>(doctorSpec.PageSize, doctorSpec.PageIndex, count, data));
        }
        #endregion

        #region get nurse by Patient Id list
        [HttpGet("nurse")]
        public async Task<ActionResult<Pagination<NurseWithPatientDto>>> GetNursesByPatientId(int patientId, [FromQuery] SpecParams nurseSpec)
        {
            var spec = new NurseWithtPatientSpecifications(patientId, nurseSpec);
            var nurses = await _unitOfWork.Repository<Nurse>().GetAllWithSpecAsync(spec);

            var countSpec = new NurseWithPatientCountSpecifications(patientId, nurseSpec);
            int count = await _unitOfWork.Repository<Nurse>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<Nurse>, IEnumerable<NurseWithPatientDto>>(nurses);

            return Ok(new Pagination<NurseWithPatientDto>(nurseSpec.PageSize, nurseSpec.PageIndex, count, data));

        }
        #endregion

        #region Get List Of (Amount,Appoinment,MedicalHistory)

        #region bills
        [HttpGet("bills")]
        public async Task<ActionResult<Pagination<BillWithPatientDTO>>> GetBilltByPatientId([FromQuery] BASpecParams BillSpec)
        {
            var spec = new BillWithPatientSpecifications(BillSpec);
            var bills = await _unitOfWork.Repository<Bill>().GetAllWithSpecAsync(spec);

            var countSpec = new BillCountWithPatientSpecifications(BillSpec);
            int count = await _unitOfWork.Repository<Bill>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<Bill>, IEnumerable<BillWithPatientDTO>>(bills);

            return Ok(new Pagination<BillWithPatientDTO>(BillSpec.PageSize, BillSpec.PageIndex, count, data));
        }
        #endregion

        #region appoinments

        [HttpGet("appoinments")]
        public async Task<ActionResult<Pagination<AppoinmentWithPatientDTO>>> GetAppoinmentByPatientId([FromQuery] BASpecParams appoinmentSpec)
        {
            var spec = new AppoinmentWithPatientSpecifications(appoinmentSpec);
            var appoinments = await _unitOfWork.Repository<Appointment>().GetAllWithSpecAsync(spec);

            var countSpec = new AppoinmentCountWithPatientSpecifications(appoinmentSpec);
            int count = await _unitOfWork.Repository<Appointment>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppoinmentWithPatientDTO>>(appoinments);

            return Ok(new Pagination<AppoinmentWithPatientDTO>(appoinmentSpec.PageSize, appoinmentSpec.PageIndex, count, data));
        }
        #endregion

        #region medical

        [HttpGet("medical")]
        public async Task<ActionResult<Pagination<MedicalWithPatientDTO>>> GetMedicalByPatientId([FromQuery] BASpecParams medicalSpec)
        {
            var spec = new MedicalWithPatientSpecifications(medicalSpec);
            var medicals = await _unitOfWork.Repository<MedicalHistory>().GetAllWithSpecAsync(spec);

            var countSpec = new MedicalCountWithPatientSpecifications(medicalSpec);
            int count = await _unitOfWork.Repository<MedicalHistory>().GetCountAsync(countSpec);

            var data = _mapper.Map<IEnumerable<MedicalHistory>, IEnumerable<MedicalWithPatientDTO>>(medicals);

            return Ok(new Pagination<MedicalWithPatientDTO>(medicalSpec.PageSize, medicalSpec.PageIndex, count, data));
        }
        #endregion

        #endregion

        #region Update Data Of Patient 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("update")]
        public async Task<ActionResult> UpdatePatient(int patientId, [FromBody] UpdatePatientDTO updatePatientDTO)
        {
            var patientRepository = _unitOfWork.Repository<Patient>();
            var patient = await patientRepository.GetByIdAsync(patientId);

            if (patient == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _mapper.Map(updatePatientDTO, patient);
            patientRepository.Update(patient);

            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return NoContent();
            }
            throw new Exception($"Updating patient {patientId} failed on save");
        }
        #endregion

    }

}

