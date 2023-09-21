using GYMmanagement.DtOs.Schedule;
using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.BookingDtO
{
    public class GetBookingDtO
    {
        public Guid Id { get; set; }
        public GetMemberDtO Member { get; set; }
        public GetScheduleDtO Class  { get; set; }
        public bool Status { get; set; }
    }
}
