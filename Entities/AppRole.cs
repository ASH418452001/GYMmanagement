using Microsoft.AspNetCore.Identity;

namespace GYMmanagement.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
