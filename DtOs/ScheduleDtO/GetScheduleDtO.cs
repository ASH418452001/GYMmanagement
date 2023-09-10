using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.Schedule
{
    public class GetScheduleDtO
    {
        public int Id { get; set; }
        public Class Class { get; set; }
        public string ClassTime { get; set; }//Take it 2 TIME , One as DateOnly & Second as TimeOnly
        public string ClassDate { get; set; }//Take it 2 TIME , One as DateOnly & Second as TimeOnly

    }
}
