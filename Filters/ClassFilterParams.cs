using GYMmanagement.Helpers;

namespace GYMmanagement.Filters
{
    public class ClassFilterParams: PaginationParams
    {
        public Guid? TrainerId { get; set; }
        public string? ClassName { get; set; }
      
    }
}
