using Her.Services.DictionaryService;
using Her.Services.UserService;
using Her.ViewModel;
using Her.ViewModel.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Her.Web.Controllers
{
	public class UserController : Controller
    {
        private readonly IUserService _userService;
		private readonly IDictionaryServices _dictionaryService;

        public UserController(IUserService userService, IDictionaryServices dictionary)
        {
            _userService = userService;
			_dictionaryService = dictionary;
        }
        public IActionResult Settings()
        {
            var settings = _userService.GetUserNameSettings();
			return View(settings);
        }

		public IActionResult EditUserSettings()
		{
			var setting = _userService.GetUserNameSettings();
			var settings = new Tuple<SettingViewModel,List<IntrestViewModel>>(setting,_dictionaryService.GetInterest());
			return View(settings);
		}

		[HttpPost]
		public IActionResult SaveUserSettings(SettingViewModel model)
		{
			_userService.SaveUserSettings(model);
			return RedirectToAction("Settings");
		}

		[HttpPost]
		public IActionResult SaveUserInterest(List<string> Name,List<bool> Value,List<int> id)
		{
			var sett = new List<IntrestViewModel>();

			for (int i = 0; i < Name.Count(); i++)
			{
				sett.Add(new IntrestViewModel()
				{
					Name = Name[i],
					Id = id[i],
					IsTrue = Value[i],
				});
			}
			_userService.SaveUserInterest(sett);
			return RedirectToAction("Settings");
		}

		[HttpPost]
		public IActionResult SaveUserNotification(UserCustomNotificationViewModel model)
		{
			_userService.SaveUserNotification(model);
			return RedirectToAction("Settings");
		}
		[HttpPost]
		public IActionResult SaveUserPersonalSettings(UserCustomSettingsViewModel model)
		{
			_userService.SaveUserSettings(model);
			return RedirectToAction("Settings");
		}

	}
}

//http://dev.wroclaw.pl/go/docs/#-6163103