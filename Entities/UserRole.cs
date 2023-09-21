using Microsoft.AspNetCore.Identity;

namespace GYMmanagement.Entities
{
    public class UserRole : IdentityUserRole<Guid>
    {
        public User USER { get; set; }
        public AppRole Role { get; set; }
    }
}
