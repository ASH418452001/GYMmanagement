using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.FeedBacksDtO;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using GYMmanagement.Interfaces.RepstroyInterfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GYMmanagement.Repostories
{
    public class FeedbackRepostory : IFeedbackRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FeedbackRepostory(DataContext context,IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateFeedback(Feedback feedback)
        {
            _context.Feedback.Add(feedback);
            //_context.actionLoggers.Add(new ActionLogger()
            //{
            //    ActionName = "Createfeedback",
            //    CreateDataTime = DateTime.UtcNow,
            //    ReferenceId = feedback.Id,
            //    JsonData = JsonConvert.SerializeObject(feedback),
            //    TableName = "feedback",
            //    UserId = feedback.Id
            //});
            _context.SaveChanges();

        }

        public async Task<PagedList<GetFeedBacksDtO>> GetFeedback(FilterParams filterParams)
        {
            var a = _context.Feedback.AsQueryable().Include(a => a.Member)
                 .Where(a => filterParams.Id == null || a.MemberId == filterParams.Id)
                 .Where(a => filterParams.FromDate == null || a.Date >= filterParams.FromDate)
                 .Where(a => filterParams.ToDate == null || a.Date <= filterParams.ToDate)
             .AsNoTracking();

            return await PagedList<GetFeedBacksDtO>.CreateAsync(a
           .ProjectTo<GetFeedBacksDtO>(_mapper.ConfigurationProvider),
               filterParams.PageNumber, filterParams.PageSize);
        }
    }
}
