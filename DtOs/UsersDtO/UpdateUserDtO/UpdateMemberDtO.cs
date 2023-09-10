using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.DtOs.UsersDtO.Update
{
    public class UpdateMemberDtO
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }


       
 
    }
}
