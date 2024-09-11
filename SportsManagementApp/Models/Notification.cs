using System.ComponentModel.DataAnnotations;

namespace SportsManagementApp.Models
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public User User { get; set; }
    }
}
