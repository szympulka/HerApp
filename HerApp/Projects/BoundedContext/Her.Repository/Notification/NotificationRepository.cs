using System;
using System.Collections.Generic;
using System.Text;
using Her.Domain.Entities;

namespace Her.Repository.Notification
{
    public class NotificationRepository: SqlRepository<NotificationModel> , INotificationRepository
    {
    }
}
