using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;
using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.FeedBacksDtO
{
    public class GetFeedBacksDtO
    {
        public int Id { get; set; }
        public GetMemberDtO Member { get; set; }
        
        public DateTime Date { get; set; }
        public double Rate { get; set; }
        public string Comments { get; set; }
    }
}
