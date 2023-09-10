using GYMmanagement.Helpers;

namespace GYMmanagement.Filters
{
    public class UserParams : PaginationParams
    {
        public string CurrentUsername { get; set; }
    }
}
