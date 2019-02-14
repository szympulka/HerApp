using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities
{
	[Table("UserDailyNotificationModel", Schema = "user")]

	public class UserCustomNotificationModel
	{
		public virtual TimeSpan RememberTime { get; set; }
		public virtual bool NotificationTask { get; set; }
		public virtual bool NotificationWeather { get; set; }
		public virtual bool NotificationEvent { get; set; }
		public virtual bool IsActive { get; set; }
		[Key]
		public virtual string UserID { get; set; }
		[ForeignKey("UserID")]
		public virtual ApplicationUser User { get; set; }
	}
}
