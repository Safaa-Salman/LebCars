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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RideAttendee>(x => x.HasKey(aa => new {aa.AppUserId, aa.RideId}));

            builder.Entity<RideAttendee>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Rides)
                .HasForeignKey(aa => aa.AppUserId);

            builder.Entity<RideAttendee>()
                .HasOne(u => u.Ride)
                .WithMany(a => a.Attendees)
                .HasForeignKey(aa => aa.RideId);
        }
    }
}