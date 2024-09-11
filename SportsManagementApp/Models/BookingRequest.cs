using SportsManagementApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApplication.Models
{
    public class BookingRequest
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime BookingTime { get; set; }

        // Foreign key property
        public Guid UserId { get; set; }

        // Navigation property
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int DurationInHours { get; set; }
        public List<Guid> UserIdList { get; set; }
    }
}
