using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.DtOs.UsersDtO.Create;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GYMmanagement.Repostories
{
    public class PaymentRepostory : IPaymentRepostory
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PaymentRepostory(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreatePayment(Payment payment)
        {
            _context.Payment.Add(payment);
            _context.actionLoggers.Add(new ActionLogger()
            {
                ActionName = "CreatePayment",
                CreateDataTime = DateTime.UtcNow,
                ReferenceId = payment.Id,
                JsonData = JsonConvert.SerializeObject(payment),
                TableName = "Payment",
                UserId = payment.Id 
            }) ;
            _context.SaveChanges();

        }

      


      

        public async Task<PagedList<GetPaymentDtO>>GetPayment(FilterParams filterParams)
        {
            var a =  _context.Payment.AsQueryable().Include(a => a.Member)
                .Where(a => filterParams.Id == null || a.MemberId == filterParams.Id)
                .Where(a => filterParams.FromDate == null || a.PaymentDate >= filterParams.FromDate)
                .Where(a => filterParams.ToDate == null || a.PaymentDate <= filterParams.ToDate)
            .AsNoTracking();

            return await PagedList<GetPaymentDtO>.CreateAsync(a
           .ProjectTo<GetPaymentDtO>(_mapper.ConfigurationProvider),
               filterParams.PageNumber, filterParams.PageSize);
        }
        
    }
}
