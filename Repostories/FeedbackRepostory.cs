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

        public async Task<PagedList<GetFeedBacksDtO>> GetFeedback(BasicMemberFilterParams basicMemberFilterParams)
        {
            var a = _context.Feedback.AsQueryable().Include(a => a.Member)
                 .Where(a => basicMemberFilterParams.MemberId == null || a.MemberId == basicMemberFilterParams.MemberId)
                 .Where(a => basicMemberFilterParams.FromDate == null || a.Date >= basicMemberFilterParams.FromDate)
                 .Where(a => basicMemberFilterParams.ToDate == null || a.Date <= basicMemberFilterParams.ToDate)
             .AsNoTracking();

            return await PagedList<GetFeedBacksDtO>.CreateAsync(a
           .ProjectTo<GetFeedBacksDtO>(_mapper.ConfigurationProvider),
               basicMemberFilterParams.PageNumber, basicMemberFilterParams.PageSize);
        }
    }
}
