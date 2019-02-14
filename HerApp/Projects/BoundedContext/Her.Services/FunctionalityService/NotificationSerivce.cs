using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Her.Repository.Notification;

namespace Her.Services.FunctionalityService
{
    public class NotificationSerivce: INotificationSerivce
    {
        private INotificationRepository _notificationRepository;

        public NotificationSerivce(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public void ChangeStatus(long Id)
        {
            var notif = _notificationRepository.All().First(x => x.Id == Id);
            if (notif.UserID == null) return;
            notif.IsReaded = !notif.IsReaded;
            _notificationRepository.Attach(notif);
            _notificationRepository.SaveChanges();
        }
    }
}
