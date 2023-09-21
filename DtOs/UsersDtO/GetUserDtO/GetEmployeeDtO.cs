using GYMmanagement.DtOs.UsersDtO.Create;
using GYMmanagement.Helpers;

namespace GYMmanagement.DtOs.UsersDtO.UpdateUserDtO
{
    public class GetEmployeeDtO : UserInformation
    {
       
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

    }
}
