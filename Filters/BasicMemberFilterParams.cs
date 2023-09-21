using GYMmanagement.Helpers;

namespace GYMmanagement.Filters
{
    public class BasicMemberFilterParams: PaginationParams
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Guid? MemberId { get; set; }
    }
}
