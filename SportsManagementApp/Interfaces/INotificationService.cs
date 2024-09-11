using SportsManagementApp.Models;

namespace SportsManagementApp.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(Notification notification);
    }
}
