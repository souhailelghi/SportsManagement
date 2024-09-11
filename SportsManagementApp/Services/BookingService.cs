using BookingApplication.Models;
using Microsoft.EntityFrameworkCore;
using SportsManagementApp.Data;
using SportsManagementApp.Models;

namespace BookingApplication.Services
{
    public class BookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CanTeamOrUserBookAsync(Guid userId, List<Guid> UserIdList)
        {
            var oneMinuteAgo = DateTime.UtcNow.AddMinutes(-1);

            // Check if the main user has an active booking in the last minute
            var existingBooking = await _context.Bookings
                .Where(b => b.UserId == userId && b.CreatedAt >= oneMinuteAgo)
                .FirstOrDefaultAsync();

            if (existingBooking != null)
            {
                return false; // User has a booking within the last minute
            }

            // Check if all users in UserIdList exist in the database
            var usersExist = await _context.Users
                .Where(u => UserIdList.Contains(u.UserId))
                .Select(u => u.UserId)
                .ToListAsync();

            if (usersExist.Count != UserIdList.Count)
            {
                return false; // Some users from the list don't exist in the database
            }

            // Check if any team member has an active booking in the last minute
            var teamBookingExists = await _context.Bookings
                .Where(b => UserIdList.Contains(b.UserId) && b.CreatedAt >= oneMinuteAgo)
                .AnyAsync();

            return !teamBookingExists; // Return true if no team members have bookings in the last minute
        }

        // Method to check if a team of users OR the user has an active booking within the last 1 minute.
        //public async Task<bool> CanTeamOrUserBookAsync(Guid userId, List<Guid> UserIdList)
        //{
        //    var oneMinuteAgo = DateTime.UtcNow.AddMinutes(-1);

        //    // Check if any player in the team or the user has an active booking in the last minute
        //    var existingBooking = await _context.Bookings
        //        .Where(b => b.UserId == userId && b.CreatedAt >= oneMinuteAgo)
        //        .FirstOrDefaultAsync();

        //    return existingBooking == null;
        //}

        // Main booking method that includes checking both the user and team members' booking restrictions
        public async Task<bool> BookAsync(Guid userId, DateTime bookingTime, int durationInHours, List<Guid> UserIdList)
        {
            // Check if the user or any team member has an existing booking within the last minute
            if (!await CanTeamOrUserBookAsync(userId, UserIdList))
            {
                return false;
            }

            // Create new booking if allowed
            var booking = new Booking
            {
                UserId = userId,
                BookingTime = bookingTime,
                DurationInHours = durationInHours,
                CreatedAt = DateTime.UtcNow
            };

            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
