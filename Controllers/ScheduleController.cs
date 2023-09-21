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



        //[Authorize(Policy = "RequireEmplyeeRole&TrainerRole")]
        [HttpPut]
        public async Task<ActionResult> UpdateSchedule(Create_UpdateScheduleDtO updateScheduleDtO, Guid Id)
        {
            await _uow.ScheduleRepostory.Update(updateScheduleDtO, Id);

            if (await _uow.Complete())
                return Ok();
            return BadRequest("Failed to update Schedule");


        }


        //[Authorize(Policy = "RequireEmplyeeRole&TrainerRole")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSchedule(Guid id)
        {


            var schedule = await _uow.ScheduleRepostory.GetByScheduleId(id);

            _uow.ScheduleRepostory.DeleteSchedule(schedule);



            if (await _uow.Complete()) return Ok("Been Deleted");

            return BadRequest("Problem deleting the Schedule");
        }



    }
}
