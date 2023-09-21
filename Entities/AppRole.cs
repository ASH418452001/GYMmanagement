using Microsoft.AspNetCore.Identity;

namespace GYMmanagement.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
