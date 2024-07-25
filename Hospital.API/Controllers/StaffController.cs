using AutoMapper;
using Hospital.API.DTO;
using Hospital.API.DTO.RoleofStaffDTO;
using Hospital.API.Errors;
using Hospital.Core.Models.Domain;
using Hospital.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    public class StaffController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region HR  Date (Doctor)

        #region Add
        [ProducesResponseType(typeof(AddDctorDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("addDoctor")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> AddDoctor(AddDctorDTO doctorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400));
            }


            if (string.IsNullOrEmpty(doctorDto.Password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(doctorDto.Password));
            }
            doctorDto.Password = BCrypt.Net.BCrypt.HashPassword(doctorDto.Password);
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _unitOfWork.Repository<Doctor>().AddAsync(doctor);
            await _unitOfWork.CompleteAsync();

            return Ok(doctor);
        }

        #endregion

        #region Update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("update")]
        [Authorize(Roles = "HR")]
        public async Task<ActionResult> UpdateDoctor(int DoctorId, [FromBody] UpdateDoctorDTO updateDTO)
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

        #region Delete
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("deleteDoctor")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _unitOfWork.Repository<Doctor>().Remove(doctor);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        #endregion


        #endregion

        #region HR  Date (Staff)

        #region Add
        [ProducesResponseType(typeof(AddStaffDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("addStaff")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> AddStaff(AddStaffDTO staff_Dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Model State is not valid"));
            }
            if (string.IsNullOrEmpty(staff_Dto.Password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(staff_Dto.Password));
            }
            staff_Dto.Password = BCrypt.Net.BCrypt.HashPassword(staff_Dto.Password);
            var staff = _mapper.Map<Staff>(staff_Dto);
            await _unitOfWork.Repository<Staff>().AddAsync(staff);
            await _unitOfWork.CompleteAsync();

            return Ok(staff);
        }

        #endregion

        #region Update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("updateStaff")]
        [Authorize(Roles = "HR")]
        public async Task<ActionResult> UpdateStaff(int staffId, [FromBody] UpdateStaffDto staff_Dto)
        {
            var StaffRepository = _unitOfWork.Repository<Staff>();
            var staff = await StaffRepository.GetByIdAsync(staffId);

            if (staff == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _mapper.Map(staff_Dto, staff);
            StaffRepository.Update(staff);
            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return NoContent();
            }

            throw new Exception($"Updating patient {staffId} failed on save");
        }


        #endregion

        #region Delete
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("deleteStaff")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _unitOfWork.Repository<Staff>().GetByIdAsync(id);
            if (staff == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _unitOfWork.Repository<Staff>().Remove(staff);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        #endregion

        #region Update Password Staff
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("updatePasswordStaff")]

        public async Task<ActionResult> UpdateStaff(int staffId, [FromBody] UpdatePasswordWithStaff staff_Dto)
        {
            var StaffRepository = _unitOfWork.Repository<Staff>();
            var staff = await StaffRepository.GetByIdAsync(staffId);

            if (staff == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _mapper.Map(staff_Dto, staff);
            StaffRepository.Update(staff);
            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return NoContent();
            }

            throw new Exception($"Updating patient {staffId} failed on save");
        }
        #endregion

        #endregion

        #region HR  Date (Nurse)

        #region Add
        [ProducesResponseType(typeof(AddNurseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("addNurse")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> AddNurse(AddNurseDTO nurse_DTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Model state is not valid"));
            }
            if (string.IsNullOrEmpty(nurse_DTO.Password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(nurse_DTO.Password));
            }
            nurse_DTO.Password = BCrypt.Net.BCrypt.HashPassword(nurse_DTO.Password);
            var nurse = _mapper.Map<Nurse>(nurse_DTO);
            await _unitOfWork.Repository<Nurse>().AddAsync(nurse);
            await _unitOfWork.CompleteAsync();

            return Ok(nurse);
        }

        #endregion

        #region Update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("updateNurse")]
        [Authorize(Roles = "HR")]
        public async Task<ActionResult> UpdateNurse(int nurseId, [FromBody] UpdateNurseDTO nurse_DTO)
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

        #region Delete
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("deleteNurse")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> DeleteNurse(int id)
        {
            var nurse = await _unitOfWork.Repository<Nurse>().GetByIdAsync(id);
            if (nurse == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _unitOfWork.Repository<Nurse>().Remove(nurse);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        #endregion

        #endregion

        #region Manager Date (Bill)

        #region Add
        [ProducesResponseType(typeof(Bill_DTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("addBill")]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> AddBill(Bill_DTO bill_DTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Model state is not valid"));
            }

            var bill = _mapper.Map<Bill>(bill_DTO);
            await _unitOfWork.Repository<Bill>().AddAsync(bill);
            await _unitOfWork.CompleteAsync();

            return Ok(bill);
        }

        #endregion

        #region Update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("updateBill")]
        [Authorize(Roles = "Management")]
        public async Task<ActionResult> UpdateBill(int BillId, [FromBody] BillDTO updateDTO)
        {
            var BillRepository = _unitOfWork.Repository<Bill>();
            var bill = await BillRepository.GetByIdAsync(BillId);

            if (bill == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _mapper.Map(updateDTO, bill);
            BillRepository.Update(bill);
            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return NoContent();
            }

            throw new Exception($"Updating patient {BillId} failed on save");
        }


        #endregion

        #region Delete
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("deleteBill")]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var bill = await _unitOfWork.Repository<Bill>().GetByIdAsync(id);
            if (bill == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _unitOfWork.Repository<Bill>().Remove(bill);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        #endregion

        #endregion

        #region Manager  Date (Appoinment)

        #region Add
        [ProducesResponseType(typeof(Appoinment_DTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("addAppoinment")]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> AddAppoinment(Appoinment_DTO appoinment_DTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400, "Model state is not valid"));
            }

            var appointment = _mapper.Map<Appointment>(appoinment_DTO);
            await _unitOfWork.Repository<Appointment>().AddAsync(appointment);
            await _unitOfWork.CompleteAsync();

            return Ok(appointment);
        }

        #endregion

        #region Update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpPut("updateAppointment")]
        [Authorize(Roles = "Management")]
        public async Task<ActionResult> UpdateAppoinment(int AppointmentId, [FromBody] Appoinment_DTO updateDTO)
        {
            var AppointmentRepository = _unitOfWork.Repository<Appointment>();
            var appointment = await AppointmentRepository.GetByIdAsync(AppointmentId);

            if (appointment == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _mapper.Map(updateDTO, appointment);
            AppointmentRepository.Update(appointment);
            if (await _unitOfWork.CompleteAsync() > 0)
            {
                return NoContent();
            }

            throw new Exception($"Updating patient {AppointmentId} failed on save");
        }


        #endregion

        #region Delete
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpDelete("deleteAppointment")]
        [Authorize(Roles = "Management")]
        public async Task<IActionResult> DeleteAppoinment(int id)
        {
            var appoinment = await _unitOfWork.Repository<Appointment>().GetByIdAsync(id);
            if (appoinment == null)
            {
                return NotFound(new ApiResponse(404));
            }

            _unitOfWork.Repository<Appointment>().Remove(appoinment);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        #endregion


        #endregion
    }
}
