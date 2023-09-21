namespace GYMmanagement.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public DateTime ClassTimes { get; set; }//Take it 2 TIME , One as DateOnly & Second as TimeOnly
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        
        
    }
}
