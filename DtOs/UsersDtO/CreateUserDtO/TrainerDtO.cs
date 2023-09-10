using GYMmanagement.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.DtOs.UsersDtO.Create
{
    public class TrainerDtO : UserInformation
    {
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Specialties { get; set; }
        [Required]
        public string Certification { get; set; }
    }
}
