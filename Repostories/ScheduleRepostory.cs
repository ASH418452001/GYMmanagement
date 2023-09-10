using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.Schedule;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces.RepstroyInterfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GYMmanagement.Repostories
{
    public class ScheduleRepostory : IScheduleRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ScheduleRepostory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateSchedule(Schedule schedule)
        {

            _context.Schedule.Add(schedule);
            //_context.actionLoggers.Add(new ActionLogger()
            //{
            //    ActionName = "Createschedule",
            //    CreateDataTime = DateTime.UtcNow,
            //    ReferenceId = schedule.Id,
            //    JsonData = JsonConvert.SerializeObject(schedule),
            //    TableName = "schedule",
            //    UserId = schedule.Id
            //});
            _context.SaveChanges();
        }

        public async Task<PagedList<GetScheduleDtO>> GetSchedule(FilterParams filterParams)
        {
             var a =  _context.Schedule.AsQueryable().Include(a => a.Class)
                .Where(a => filterParams.Id == null || a.ClassId == filterParams.Id)
                .Where(a => filterParams.FromDate == null || a.ClassTimes >= filterParams.FromDate)
                .Where(a => filterParams.ToDate == null || a.ClassTimes <= filterParams.ToDate)
            .AsNoTracking();

            return await PagedList<GetScheduleDtO>.CreateAsync(a
           .ProjectTo<GetScheduleDtO>(_mapper.ConfigurationProvider),
               filterParams.PageNumber, filterParams.PageSize);
        }
    }
}
