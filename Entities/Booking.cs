﻿namespace GYMmanagement.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public User Member { get; set; }
        public int ClassId { get; set; }
        public Class AClass { get; set; }


        public int scheduleId { get; set; }//In DtO we should bring it two times , once as DateOnly  & another as TimeOnly
        public Schedule ClassDate { get; set; }

        public bool Status { get; set; }    
    }
}