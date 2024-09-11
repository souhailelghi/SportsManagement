using SportsManagementApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BookingApplication.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime BookingTime { get; set; }
        public int DurationInHours { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public User User { get; set; }
    }

      
}
