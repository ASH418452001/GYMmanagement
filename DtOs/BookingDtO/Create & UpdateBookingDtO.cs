using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.BookingDtO
{
    public class Create___UpdateBookingDtO
    {
       
        
        public Guid MemberId { get; set; }
       
        public string ScheduleId { get; set; }



        public DateTime BookingDate { get; set; } 
        public DateTime BookingExpireDate { get; set; } 




        public bool Status { get; set; }
    }
}
