using GYMmanagement.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GYMmanagement.Data
{
    public class DataContext : IdentityDbContext<User, AppRole
        , Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>
        , IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ActionLogger> actionLoggers { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Class> Classe { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Payment> Payment { get; set; }
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




            builder.Entity<Class>()
                .HasOne(m => m.CreatedByUser)
                .WithMany()
                .HasForeignKey(cbu => cbu.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Class>()
                .HasOne(m => m.LastUpdatedByUser)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);



            builder.Entity<Class>()
                .HasOne(m => m.LastDeletedByUser)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Payment>()
                .HasOne(m => m.CreatedByUser)
                .WithMany()
                .HasForeignKey(cbu => cbu.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Payment>()
                .HasOne(m => m.LastUpdatedByUser)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);



            builder.Entity<Payment>()
                .HasOne(m => m.LastDeletedByUser)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);




            builder.Entity<Class>()
                .HasOne(m => m.Trainer)
                .WithMany()
                .HasForeignKey(ti => ti.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                




         



            builder.Entity<Payment>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Payments)
                .HasForeignKey(ti => ti.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);




            builder.Entity<Schedule>()
                .HasOne(m => m.Class)
                .WithMany(umt => umt.schedules)
                .HasForeignKey(ci => ci.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull);





            builder.Entity<Attendance>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Attendances)
                .HasForeignKey(mi => mi.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);

           
                

         
                







            builder.Entity<Feedback>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Feedbacks)
                .HasForeignKey(mt => mt.MemberId);






            builder.Entity<Booking>()
                .HasOne(m => m.Member)
                .WithMany(umt => umt.Bookings)
                .HasForeignKey(mi => mi.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);


      
                


            builder.Entity<Booking>()
                .HasOne(m => m.Class)
                .WithMany(umt => umt.Bookings)
                .HasForeignKey(si =>si.scheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                








        }


    }
}
