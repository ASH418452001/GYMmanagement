using GYMmanagement.DtOs.AttendanceDtO;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Interfaces.RepstroyInterfaces.UserRepostoyInterfaces
{
    public interface IAttendanceRepostory
    {
        Task<PagedList<GetAttendanceDtO>> GetAttendance(BasicMemberFilterParams attendanceFilterParams);

        Task<PagedList<GetAttendanceForMemberDtO>> GetAttendanceForMember(DateParams dateParams, Guid Id);     
        void CreateAttendance(Guid UserId);
        
    }
}
