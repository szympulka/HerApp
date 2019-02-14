using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Her.ViewModel.UserViewModels
{
	public class UserCustomNotificationViewModel
	{
		[Display(Name = "Remember me")]
		public TimeSpan RememberTime { get; set; }
		[Display(Name = "Task")]
		public bool NotificationTask { get; set; }
		[Display(Name = "Weather")]
		public bool NotificationWeather { get; set; }
		[Display(Name = "Event")]
		public bool NotificationEvent { get; set; }
		[Display(Name = "Is Active")]
		public bool IsActive { get; set; }
	}
}
