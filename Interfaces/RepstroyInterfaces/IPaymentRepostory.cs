
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


        Task<PagedList<GetPaymentDtO>> GetPayment(FilterParams filterParams);
      
     
        void CreatePayment(Payment payment);
        
    }
}
