namespace GYMmanagement.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public int Capacity { get; set; }
        
        public int TrainerId { get; set; }
        public User Trainer { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public ICollection<Booking> Bookings { get; set; }
   
        public ICollection<Schedule> schedules { get; set; }
        public ICollection<Attendance> AttendancesId { get; set; }


    }
}
