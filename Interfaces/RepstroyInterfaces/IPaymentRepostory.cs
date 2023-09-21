
using GYMmanagement.DtOs.ClassDtO;
using GYMmanagement.DtOs.PaymentDtO;
using GYMmanagement.Entities;
using GYMmanagement.Filters;
using GYMmanagement.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GYMmanagement.Interfaces
{
    public interface IPaymentRepostory
    {


        Task<PagedList<GetPaymentDtO>> GetPayment(BasicMemberFilterParams basicMemberFilterParams);
        void DeletePayment(Payment payment);
        Task<Payment> GetPaymentsById(Guid id);

        Task Update(CreateUpdatePaymentDtO updatePaymentDtO, Guid Id);
        void CreatePayment(Payment payment);
        
    }
}
