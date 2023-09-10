using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.DtOs.Schedule;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;

namespace GYMmanagement.Interfaces.RepstroyInterfaces
{
    public interface IScheduleRepostory
    {
        Task<PagedList<GetScheduleDtO>> GetSchedule(FilterParams filterParams);


        void CreateSchedule(Schedule schedule);
    }
}
