﻿using GYMmanagement.Helpers;

namespace GYMmanagement.Filters
{
    public class FilterParams : PaginationParams
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Guid? UserId { get; set; }
        
    }
}
