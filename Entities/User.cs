using Microsoft.AspNetCore.Identity;

namespace GYMmanagement.Entities
{
    public class User : IdentityUser<int>
    {
        public string? Certification { get; set; }
        public string? Specialties { get; set; }
        public string? Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        public string? MemberShipType { get; set; }
    
        public ICollection<Booking> Bookings { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
