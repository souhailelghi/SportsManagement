using BookingApplication.Models;
using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Models;

namespace SportsManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BookingRequest> BookingRequests { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }
       // public DbSet<Field> Fields { get; set; }
       // public DbSet<Notification> Notifications { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingRequest>()
                .HasOne(br => br.User)
                .WithMany() // Adjust if you have a collection navigation property in User
                .HasForeignKey(br => br.UserId)
                .OnDelete(DeleteBehavior.Restrict); // or .OnDelete(DeleteBehavior.Cascade) based on your needs
        }
    }
}
