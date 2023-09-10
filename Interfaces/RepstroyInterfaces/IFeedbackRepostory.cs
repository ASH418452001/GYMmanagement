using GYMmanagement.DtOs.FeedBacksDtO;
using GYMmanagement.DtOs.Schedule;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;

namespace GYMmanagement.Interfaces.RepstroyInterfaces
{
    public interface IFeedbackRepostory
    {
        Task<PagedList<GetFeedBacksDtO>> GetFeedback(FilterParams filterParams);


        void CreateFeedback(Feedback feedback);
    }
}
