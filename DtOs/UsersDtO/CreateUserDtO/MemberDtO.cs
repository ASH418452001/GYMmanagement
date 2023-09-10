using System.ComponentModel.DataAnnotations;
using GYMmanagement.Helpers;

namespace GYMmanagement.DtOs.UsersDtO.Create
{
    public class MemberDtO : UserInformation
    {

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string MemberShipType { get; set; }

       


        [Required]
        public DateTime StartDate { get; set; }


        [Required]
        public DateTime EndDate { get; set; }


    }
}
