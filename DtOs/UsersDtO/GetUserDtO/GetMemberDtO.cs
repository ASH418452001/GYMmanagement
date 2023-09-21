using GYMmanagement.DtOs.UsersDtO.Create;
using GYMmanagement.Helpers;

namespace GYMmanagement.DtOs.UsersDtO.UpdateUserDtO
{
    public class GetMemberDtO : UserInformation
    {
       
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string MemberShipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
