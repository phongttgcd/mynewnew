using COMP1640_WebDev.Models;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotifications();
        Task<Notification>? GetNotification(string idNotification);
        Task<Notification> CreateNotification(Notification notification);
        Task<Notification> RemoveNotification(string idNotification);
        Task<Notification> UpdateNotification(string idNotification, Notification notification);
    }
}
