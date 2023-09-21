
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.AttendanceDtO;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GYMmanagement.Repostories
{
    public class AttendanceRepostory : IAttendanceRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AttendanceRepostory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateAttendance(Guid UserId)
        {
            var entity = new Attendance()
            {
                MemberId = UserId,
                Date = DateTime.UtcNow,
                Status = true,

            };
            _context.Attendance.Add(entity);
                
                
            //_context.actionLoggers.Add(new ActionLogger()
            //{
            //   ActionName = "CreateAttendance",
            //   CreateDataTime = DateTime.UtcNow,
            //   ReferenceId = entity.Id,
            //   JsonData = JsonConvert.SerializeObject(entity),
            //   TableName = "Attendance",
            //   UserId = UserId
            //});
            _context.SaveChanges();

        }

        public async Task<PagedList<GetAttendanceDtO>> GetAttendance(BasicMemberFilterParams attendanceFilterParams)
        {

            var a = _context.Attendance.AsQueryable().Include(a => a.Member)
                .Where(a => attendanceFilterParams.MemberId == null || a.MemberId == attendanceFilterParams.MemberId)
                .Where(a => attendanceFilterParams.FromDate == null || a.Date >= attendanceFilterParams.FromDate)
                .Where(a => attendanceFilterParams.ToDate == null || a.Date <= attendanceFilterParams.ToDate)
            .AsNoTracking();

            return await PagedList<GetAttendanceDtO>.CreateAsync(a
           .ProjectTo<GetAttendanceDtO>(_mapper.ConfigurationProvider),
               attendanceFilterParams.PageNumber, attendanceFilterParams.PageSize);
        }




        public async  Task<PagedList<GetAttendanceForMemberDtO>> GetAttendanceForMember(DateParams dateParams, Guid Id)
        {

            var a = _context.Attendance.AsQueryable().Include(a => a.Member)
               .Where(a => a.Member.Id == Id) 
               .Where(a => dateParams.FromDate == null || a.Date >= dateParams.FromDate)
               .Where(a => dateParams.ToDate == null || a.Date <= dateParams.ToDate).AsNoTracking();
            

            return await PagedList<GetAttendanceForMemberDtO>.CreateAsync(a
                      .ProjectTo<GetAttendanceForMemberDtO>(_mapper.ConfigurationProvider),
                          dateParams.PageNumber, dateParams.PageSize);
        }
    }
}
