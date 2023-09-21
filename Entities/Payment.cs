namespace GYMmanagement.Entities
{
    public class Payment : BaseEntity
    {
        public Guid MemberId { get; set; } 
        public User Member { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Status { get; set; }
    }
}
