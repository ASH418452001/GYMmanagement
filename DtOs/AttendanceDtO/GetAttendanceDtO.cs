using GYMmanagement.Entities;

namespace GYMmanagement.DtOs.AttendanceDtO
{
    public class GetAttendanceDtO
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public string MemberUserName { get; set; }

        public int ClassId { get; set; }
        public string ClassName { get; set; }


        public int scheduleId { get; set; }//In DtO we should bring it two times , once as DateOnly  & another as TimeOnly
        public string ClassTime { get; set; }
        public string ClassDate { get; set; }



        public bool Status { get; set; }
    }
}
