﻿namespace GYMmanagement.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public User Member { get; set; }
        public DateTime Date { get; set; }
        public double Rate { get; set; }
        public string Comments { get; set; }    
    }
}
