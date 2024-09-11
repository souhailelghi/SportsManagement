//using SportsManagementApp.Data;
//using SportsManagementApp.Interfaces;
//using SportsManagementApp.Models;

//namespace SportsManagementApp.Services
//{
//    public class NotificationService : INotificationService
//    {
//        private readonly AppDbContext _context;

//        public NotificationService(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task SendNotificationAsync(Notification notification)
//        {
//            _context.Notifications.Add(notification);
//            await _context.SaveChangesAsync();
//            // Logic for sending email/notification
//        }
//    }
//}
