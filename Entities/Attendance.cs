namespace GYMmanagement.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }

        public Guid MemberId { get; set; }
        public User Member { get; set; }

        public DateTime Date { get; set; } 
        public bool Status { get; set; }
    }
}
