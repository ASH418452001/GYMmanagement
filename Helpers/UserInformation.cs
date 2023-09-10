using System.ComponentModel.DataAnnotations;

namespace GYMmanagement.Helpers
{
    public class UserInformation
    {
        [Required]

        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

      
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
