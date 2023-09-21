using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.FeedBacksDtO
{
    public class Create_UpdateFeedBacksDtO
    {
      
        public Guid MemberId { get; set; }
        public DateTime Date { get; set; }
        public double Rate { get; set; }
        public string Comments { get; set; }
    }
}
