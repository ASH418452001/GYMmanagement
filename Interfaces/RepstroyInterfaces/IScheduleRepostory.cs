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
        Task<Schedule> GetByScheduleId(Guid id);
        void DeleteSchedule(Schedule schedule);
        Task Update(Create_UpdateScheduleDtO updateScheduleDtO, Guid Id);
        void CreateSchedule(Schedule schedule);
    }
}
