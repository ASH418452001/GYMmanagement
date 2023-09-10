using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.PaymentDtO
{
    public class CreatePaymentDtO
    {
        
        public int MemberId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Status { get; set; }
    }
}
