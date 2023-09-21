using GYMmanagement.Helpers;

namespace GYMmanagement.Filters
{
    public class DateParams : PaginationParams
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
