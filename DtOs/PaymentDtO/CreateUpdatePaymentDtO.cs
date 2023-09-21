using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.PaymentDtO
{
    public class CreateUpdatePaymentDtO
    {
        
        public Guid MemberId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Status { get; set; }
    }
}
