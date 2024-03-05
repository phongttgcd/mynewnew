using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace COMP1640_WebDev.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public NotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Notification> CreateNotification(Notification notification)
        {
            Notification notificationToCreate = new()
            {
                UserId = notification.UserId,
                ContributionId = notification.ContributionId,
                Content = notification.Content,
                Date = DateTime.Now,
            };

            var result = await _dbContext.Notifications.AddAsync(notificationToCreate);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Notification>? GetNotification(string idNotification)
        {
            var notificationInDB = _dbContext.Notifications
                .Include(i => i.Contribution)
                .Include(u => u.User)
                .SingleOrDefault(i => i.Id == idNotification);

            if (notificationInDB == null)
            {
                return null;
            }

            return notificationInDB;
        }

        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            return await _dbContext.Notifications.ToListAsync();
        }

        public Task<Notification> RemoveNotification(string idNotification)
        {
            throw new NotImplementedException();
        }

        public async Task<Notification> UpdateNotification(string idNotification, Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
