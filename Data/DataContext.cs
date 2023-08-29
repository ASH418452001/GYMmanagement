using GYMmanagement.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GYMmanagement.Data
{
    public class DataContext : IdentityDbContext<User, AppRole
        , int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>
        , IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.USER)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();





            builder.Entity<User>()
                .HasOne(m => m.Membership)
                .WithMany(umt => umt.UsersMemberShipType)
                .HasForeignKey(mt => mt.MembershipId);





            builder.Entity <Class>()
                .HasOne(m => m.Trainer)
                .WithMany(umt => umt.Trainer)
                .HasForeignKey(mt => mt.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull);




            builder.Entity<Class>()
                .HasOne(m => m.Schedule)
                .WithMany(umt => umt.Classes)
                .HasForeignKey(mt => mt.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);



            builder.Entity<Payment>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Payments)
                .HasForeignKey(mt => mt.MemberId);




            builder.Entity<Schedule>()
                .HasOne(m => m.Class)
                .WithMany(umt => umt.schedules)
                .HasForeignKey(mt => mt.ClassId);





            builder.Entity<Attendance>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Attendances)
                .HasForeignKey(mt => mt.MemberId);

            builder.Entity<Attendance>()
                .HasOne(m => m.AClass)
                .WithMany(umt => umt.AttendancesId)
                .HasForeignKey(mt => mt.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Attendance>()
                .HasOne(m => m.Date)
                .WithMany(umt => umt.Attendances)
                .HasForeignKey(mt => mt.scheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);







            builder.Entity<Feedback>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Feedbacks)
                .HasForeignKey(mt => mt.MemberId);






            builder.Entity<Booking>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Bookings)
                .HasForeignKey(mt => mt.MemberId);


            builder.Entity<Booking>()
                .HasOne(m => m.AClass)
                .WithMany(umt => umt.Bookings)
                .HasForeignKey(mt => mt.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Booking>()
                .HasOne(m => m.ClassDate)
                .WithMany(umt => umt.Bookings)
                .HasForeignKey(mt => mt.scheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);








        }


    }
}
