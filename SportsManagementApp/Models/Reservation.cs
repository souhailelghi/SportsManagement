using System.ComponentModel.DataAnnotations;

namespace SportsManagementApp.Models
{
    public class Reservation
    {
        //public int ReservationId { get; set; }
        //public DateTime Date { get; set; }
        //public TimeSpan Time { get; set; }
        //public string FieldType { get; set; }
        //public string Status { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        [Key]
        public Guid ReservationId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string FieldType { get; set; }
        public string Part { get; set; } // "A" or "B" for football fields
        public string Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<User> Participants { get; set; }
    }
}
