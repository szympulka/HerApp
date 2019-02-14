using Her.Common.Enums;
using System;
using System.Collections.Generic;

namespace Her.ViewModel.UserViewModels
{
    public class SettingViewModel
	{
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Skype { get; set; }
        public string Microsoft { get; set; }
        public string Birthdate { get; set; }
        public string BotName { get; set; }
        public string Teams { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
		public bool IsCreated { get; set; }
		public UserCustomNotificationViewModel CustomNotifications { get; set; }
		public List<string> UserIntrest { get; set; }
		public UserCustomSettingsViewModel CustomSettings { get; set; }
	}

}
