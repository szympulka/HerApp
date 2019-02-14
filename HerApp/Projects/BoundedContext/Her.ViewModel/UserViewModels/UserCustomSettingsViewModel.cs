using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Her.ViewModel.UserViewModels
{
	public class UserCustomSettingsViewModel
	{
		[Display(Name = "Prepare daily wro events")]
		public bool DailyWroEvent { get; set; }
		[Display(Name = "Prepare Weather")]
		public bool DailyWeather { get; set; }
		[Display(Name = "Prepare daily mpk info")]
		public bool DailyMpkInfo { get; set; }
	}
}
