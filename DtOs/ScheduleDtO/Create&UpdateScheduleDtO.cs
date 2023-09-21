using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.Schedule
{
    public class Create_UpdateScheduleDtO
    {
               
        
      public Guid ClassId { get; set; }
      public DateTime ClassTimes { get; set; }//Take it 2 TIME , One as DateOnly & Second as TimeOnly


    }
}
