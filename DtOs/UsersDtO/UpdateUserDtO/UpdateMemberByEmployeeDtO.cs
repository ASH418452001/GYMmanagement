using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.DtOs.UsersDtO.Update
{
    public class UpdateMemberByEmployeeDtO
    {


        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

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
