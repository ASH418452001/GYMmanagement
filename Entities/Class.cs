using GYMmanagement.DtOs.UsersDtO.UpdateUserDtO;

namespace GYMmanagement.Entities
{
    public class Class: BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        
        public Guid TrainerId { get; set; }
        public User Trainer { get; set; }

       
        public ICollection<Schedule> schedules { get; set; }
      


    }
}
