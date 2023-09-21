namespace GYMmanagement.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public User Member { get; set; }
        


        public Guid scheduleId { get; set; }//In DtO we should bring it two times , once as DateOnly  & another as TimeOnly
      
        public Schedule Class { get; set; }

        public bool Status { get; set; }    
    }
}
