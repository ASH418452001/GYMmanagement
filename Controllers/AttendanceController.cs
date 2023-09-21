using AutoMapper;
using GYMmanagement.DtOs.AttendanceDtO;
using GYMmanagement.Extension;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AttendanceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }


        //[Authorize(Policy = "RequireMemberRole")]
        [HttpPost]
        public async Task<ActionResult> CreateAttendanceAsync()
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();

            

            _uow.AttendanceRepostory.CreateAttendance(userId);
            return Ok();

        }


        [HttpGet("for-Employee")]
        public async Task<ActionResult<IEnumerable<GetAttendanceDtO>>> GetAttendance([FromQuery] BasicMemberFilterParams attendanceFilter)
        {

            var attendance = await _uow.AttendanceRepostory.GetAttendance(attendanceFilter);
            Response.AddPaginationHeader(new PaginationHeader(attendance.CurrentPage, attendance.PageSize,
           attendance.TotalCount, attendance.TotalPages));

            return Ok(attendance);
        }


        [HttpGet("for-Member")]
        public async Task<ActionResult<IEnumerable<GetAttendanceForMemberDtO>>> GetAttendanceForMember([FromQuery] DateParams dateParams)
        {
            var userId = User.GetUserId();
            if (userId == null) return BadRequest();
            var attendance = await _uow.AttendanceRepostory.GetAttendanceForMember(dateParams, userId);


            return Ok(attendance);
        }



    } }
