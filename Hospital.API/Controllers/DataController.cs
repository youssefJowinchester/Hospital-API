using AutoMapper;
using Hospital.API.DTO;
using Hospital.API.Errors;
using Hospital.Core.Models.Domain;
using Hospital.Core.Repositories.Interfaces;
using Hospital.Core.Specifications.ModelsSpecifications.DataSpe;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    public class DataController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DataController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }


        #region get Bill list
        [ProducesResponseType(typeof(BillDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("bills")]
        public async Task<ActionResult<IEnumerable<BillDTO>>> GetBills()
        {
            var spec = new BillSpecifications();

            var bills = await _unitOfWork.Repository<Bill>().GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IEnumerable<Bill>, IEnumerable<BillDTO>>(bills);
            if (data is null)
                return NotFound(new ApiResponse(404));
            return Ok(data);
        }
        #endregion


        #region get Bill By ID
        [ProducesResponseType(typeof(BillDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("bill")]
        public async Task<ActionResult<BillDTO>> GetBillById(int Id)
        {
            var spec = new BillSpecifications(Id);

            var bill = await _unitOfWork.Repository<Bill>().GetwithSpecAsync(spec);
            var data = _mapper.Map<Bill, BillDTO>(bill);
            if (data is null)
                return NotFound(new ApiResponse(404));
            return Ok(data);
        }
        #endregion


        #region get Appoinments list
        [ProducesResponseType(typeof(AppoinmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("appoinments")]
        public async Task<ActionResult<IEnumerable<AppoinmentDTO>>> GetAppoinments()
        {
            var spec = new AppoinmentSpecifications();

            var appoinments = await _unitOfWork.Repository<Appointment>().GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppoinmentDTO>>(appoinments);
            if (data is null)
                return NotFound(new ApiResponse(404));
            return Ok(data);
        }
        #endregion


        #region get Appoinment By ID
        [ProducesResponseType(typeof(AppoinmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("appoinment")]
        public async Task<ActionResult<AppoinmentDTO>> GetAppoinmentlById(int Id)
        {
            var spec = new AppoinmentSpecifications(Id);
            var appoinment = await _unitOfWork.Repository<Appointment>().GetwithSpecAsync(spec);
            var data = _mapper.Map<Appointment, AppoinmentDTO>(appoinment);
            if (data is null)
                return NotFound(new ApiResponse(404));
            return Ok(data);
        }
        #endregion
    }
}
