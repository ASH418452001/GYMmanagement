using GYMmanagement.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.DtOs.UsersDtO.Create
{
    public class EmployeeDtO : UserInformation
    {
        [Required]
        public string Position { get; set; }
        
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
