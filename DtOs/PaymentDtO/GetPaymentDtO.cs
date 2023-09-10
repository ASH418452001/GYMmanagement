using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;

namespace GYMmanagement.DtOs.PaymentDtO
{
    public class GetPaymentDtO 
    {
        public int Id { get; set; }
        public GetMemberDtO Member {get; set;}
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Status { get; set; }
    }
}
