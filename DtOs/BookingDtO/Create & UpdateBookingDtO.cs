using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.BookingDtO
{
    public class Create___UpdateBookingDtO
    {
       
        
        public string MemberUserName { get; set; }
       
        public string ClassName { get; set; }



        public DateTime ClassTimes { get; set; }


        public bool Status { get; set; }
    }
}
