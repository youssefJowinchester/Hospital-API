using AutoMapper;
using Hospital.API.DTO;
using Hospital.API.Helpers;
using Hospital.Core.Models.Domain;
using Hospital.Core.Repositories.Interfaces;
using Hospital.Core.Specifications.ModelsSpecifications;
using Hospital.Core.Specifications.ModelsSpecifications.HomeSpe;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    public class HospitalsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public HospitalsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region get doctor list
        [HttpGet("doctors")]
        public async Task<ActionResult<IEnumerable<DocHomeDto>>> GetDoctors([FromQuery] SpecParams doctorSpec)
        {
            var spec = new DoctorWithtSpecifications(doctorSpec);
            var doctors = await _unitOfWork.Repository<Doctor>().GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DocHomeDto>>(doctors);

            var countspec = new DoctorwithCountSpecifications();
            int count = await _unitOfWork.Repository<Doctor>().GetCountAsync(countspec);

            return Ok(new Pagination<DocHomeDto>(doctorSpec.PageSize, doctorSpec.PageIndex, count, data));
        }
        #endregion



        ////////////////////////////////////comment//////////////////////////////////////////
        ////////////////////////////////////comment//////////////////////////////////////////
        ////////////////////////////////////comment//////////////////////////////////////////
        #region All Data
        //private readonly IGenericRepository<HospitalClass> _genericRepository;
        //private readonly IGenericRepository<Patient> _patient;
        //private readonly IGenericRepository<Nurse> _nurse;
        //private readonly IGenericRepository<Staff> _staff;


        //public HospitalsController(IGenericRepository<HospitalClass> genericRepository, IGenericRepository<Doctor> doctor, IGenericRepository<Patient> patient, IGenericRepository<Nurse> nurse, IGenericRepository<Staff> staff)
        //{
        //    _genericRepository = genericRepository;
        //    _doctor = doctor;
        //    _patient = patient;
        //    _nurse = nurse;
        //    _staff = staff;
        //}
        #endregion

        #region get staff list
        //[HttpGet("staffs")]
        //public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        //{
        //    var staff = await _staff.GetAllAsync();
        //    if (staff is null)
        //        return NotFound(new ApiResponse(404));
        //    return Ok(staff);
        //}
        #endregion

        #region get Patient list
        //[HttpGet("patients")]
        //public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        //{
        //    var patient = await _patient.GetAllAsync();
        //    if (patient is null)
        //        return NotFound(new ApiResponse(404));
        //    return Ok(patient);
        //}
        #endregion

        #region get nurse list
        //[HttpGet("nurses")]
        //public async Task<ActionResult<IEnumerable<Nurse>>> GetNurses()
        //{
        //    var doctor = await _nurse.GetAllAsync();
        //    if (doctor is null)
        //        return NotFound(new ApiResponse(404));
        //    return Ok(doctor);
        //}
        #endregion

    }
}
