using AutoMapper;
using AutoMapper.QueryableExtensions;
using GYMmanagement.Data;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using GYMmanagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace GYMmanagement.Repostories
{
    public class PaymentRepostory : ServiceForActionLogger<Payment>, IPaymentRepostory
    {
  


        public PaymentRepostory(DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        : base(context, httpContextAccessor, mapper)
        {
        }

        public void CreatePayment(Payment payment)
        {

            payment.SetCreateInfo(GetUserId());
            
            _context.Payment.Add(payment);
            AddActionLogger("CreateClass", payment);

            //_context.actionLoggers.Add(new ActionLogger()
            //{
            //    ActionName = "CreatePayment",
            //    CreateDataTime = DateTime.UtcNow,
            //    ReferenceId = payment.Id,
            //    JsonData = JsonConvert.SerializeObject(payment),
            //    TableName = "Payment",
            //    UserId = payment.Id 
            //}) ;
           
        }

        public async Task<Payment> GetPaymentsById(Guid id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
                throw new Exception("Not Found.");
            return payment;
        }

         public async Task Update(CreateUpdatePaymentDtO updatePaymentDtO, Guid Id)
        {

            var payment = await GetPaymentsById(Id);
            _mapper.Map(updatePaymentDtO,payment);
            payment.SetCreateInfo(GetUserId());
            _context.Entry(payment).State = EntityState.Modified;
            AddActionLogger("UpdatePayment", payment);
             
            
          
        }

        public void DeletePayment(Payment payment)
        {
            payment.SetDeleteInfo(GetUserId());
            _context.Payment.Remove(payment);
            AddActionLogger("CreateClass", payment);
        }




        public async Task<PagedList<GetPaymentDtO>>GetPayment(BasicMemberFilterParams basicMemberFilterParams)
        {
            var a =  _context.Payment.AsQueryable().Include(a => a.Member)
                .Where(a => basicMemberFilterParams.MemberId == null || a.MemberId == basicMemberFilterParams.MemberId)
                .Where(a => basicMemberFilterParams.FromDate == null || a.PaymentDate >= basicMemberFilterParams.FromDate)
                .Where(a => basicMemberFilterParams.ToDate == null || a.PaymentDate <= basicMemberFilterParams.ToDate)
              
            .AsNoTracking();

            return await PagedList<GetPaymentDtO>.CreateAsync(a
           .ProjectTo<GetPaymentDtO>(_mapper.ConfigurationProvider),
               basicMemberFilterParams.PageNumber, basicMemberFilterParams.PageSize);
        }

        
    }
}
