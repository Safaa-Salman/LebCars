using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ride> Rides { get; set; }
        public DbSet<RideAttendee> RideAttendees { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFollowing> UserFollowings { get; set; }
        public DbSet<Rating> UserRatings { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RideAttendee>(x => x.HasKey(aa => new { aa.AppUserId, aa.RideId }));

            builder.Entity<RideAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Rides)
                .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<RideAttendee>()
                .HasOne(u => u.Ride)
                .WithMany(a => a.Attendees)
                .HasForeignKey(aa => aa.RideId);

            builder.Entity<Comment>()
                .HasOne(a => a.Ride)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserFollowing>(b =>
            {
                b.HasKey(k => new { k.ObserverId, k.TargetId });

                b.HasOne(o => o.Observer)
                    .WithMany(f => f.Followings)
                    .HasForeignKey(o => o.ObserverId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(o => o.Target)
                    .WithMany(f => f.Followers)
                    .HasForeignKey(o => o.TargetId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
            builder.Entity<Rating>(b =>
            {
                b.HasKey(k => new { k.ObserverId, k.TargetId });

                b.HasOne(o => o.Observer)
                    .WithMany(r => r.RatingsHeGave)
                    .HasForeignKey(o => o.ObserverId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(o => o.Target)
                    .WithMany(f => f.RatingsHeWasGiven)
                    .HasForeignKey(o => o.TargetId)
                    .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}