using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.Schedule
{
    public class GetScheduleDtO
    {
        public Guid Id { get; set; }
        public Class Class { get; set; }
        public string ClassTime { get; set; }

    }
}
