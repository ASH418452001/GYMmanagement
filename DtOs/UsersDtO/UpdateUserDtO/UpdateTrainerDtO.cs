using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.DtOs.UsersDtO.Update
{
    public class UpdateTrainerDtO
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string Specialties { get; set; }
        [Required]
        public string Certification { get; set; }
    }
}
