//using Microsoft.EntityFrameworkCore;
//using SportsManagementApp.Data;
//using SportsManagementApp.Interfaces;
//using SportsManagementApp.Models;

//namespace SportsManagementApp.Services
//{
    
//    public class ReservationService : IReservationService
//    {
//        private readonly AppDbContext _context;

//        public ReservationService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<bool> CanReserveAsync(int userId, string fieldType, string part)
//        {
//            var now = DateTime.Now;
//            var delayDays = GetDelayDays(fieldType, part);

//            // Check if the reservation falls within allowed hours
//            if (!IsWithinAllowedHours(now, fieldType))
//            {
//                return false; // If the current time is not within allowed hours
//            }

//            // Get user's reservations within the delay period
//            var reservations = await _context.Reservations
//                .Where(r => r.UserId == userId
//                            && r.Date >= now.AddDays(-delayDays)
//                            && (r.FieldType == fieldType || r.Part == part))
//                .ToListAsync();

//            // Check if the user or their teammates have reservations within the delay period
//            foreach (var reservation in reservations)
//            {
//                var teammates = reservation.Participants.Select(p => p.UserId).ToList();
//                if (teammates.Contains(userId))
//                {
//                    return false; // Cannot reserve if any teammate has a conflicting reservation
//                }
//            }

//            return true;
//        }

//        private int GetDelayDays(string fieldType, string part)
//        {
//            if (fieldType == "Football" && (part == "A" || part == "B"))
//            {
//                return 3;
//            }
//            return fieldType switch
//            {
//                "MiniFoot" => 1,
//                "Tennis" => 1,
//                _ => 0
//            };
//        }

//        private bool IsWithinAllowedHours(DateTime dateTime, string fieldType)
//        {
//            var allowedHours = fieldType switch
//            {
//                "FootballA" => new[] { (14, 18), (22, 23) },
//                "FootballB" => new[] { (14, 18), (22, 23) },
//                "MiniFoot" => new[] { (14, 18), (20, 23) },
//                "Tennis" => new[] { (10, 18), (20, 23) },
//                _ => throw new ArgumentException("Invalid field type")
//            };

//            foreach (var (startHour, endHour) in allowedHours)
//            {
//                if (dateTime.Hour >= startHour && dateTime.Hour < endHour)
//                {
//                    return true;
//                }
//            }

//            return false;
//        }

//        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
//        {
//            if (await CanReserveAsync(reservation.UserId, reservation.FieldType, reservation.Part))
//            {
//                _context.Reservations.Add(reservation);
//                await _context.SaveChangesAsync();
//                return reservation;
//            }
//            throw new InvalidOperationException("Cannot make a reservation due to delay restrictions or invalid hours.");
//        }
//    }

//}
