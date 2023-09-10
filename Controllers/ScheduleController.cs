using AutoMapper;
using GYMmanagement.DtOs.Schedule;
using GYMmanagement.Entities;
using GYMmanagement.Extension;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ScheduleController(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }






        //[Authorize(Policy = "RequireEmplyeeRole")]
        [HttpPost]
        public async Task<ActionResult> CreateScheduleAsync(Create_UpdateScheduleDtO create_UpdateSchedule)
        {
            var classs = await _uow.ClassRepostory.GetClassByIdAsync(create_UpdateSchedule.ClassId);
            if (classs == null) return BadRequest();
            var schedule = _mapper.Map<Schedule>(create_UpdateSchedule);

            _uow.ScheduleRepostory.CreateSchedule(schedule);
            return Ok();

        }



        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetScheduleDtO>>> GetSchedule([FromQuery] FilterParams filterParams)
        {

            var schedule = await _uow.ScheduleRepostory.GetSchedule(filterParams);
            Response.AddPaginationHeader(new PaginationHeader(schedule.CurrentPage, schedule.PageSize,
           schedule.TotalCount, schedule.TotalPages));

            return Ok(schedule);
        }





    }
}
