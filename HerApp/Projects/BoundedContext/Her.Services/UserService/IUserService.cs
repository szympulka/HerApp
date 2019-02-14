using System;
using System.Collections.Generic;
using System.Net.Mime;
using Her.FunctionsViewModel.DailyWroEventFunction;
using Her.ViewModel;
using Her.ViewModel.UserViewModels;

namespace Her.Services.UserService
{
    public interface IUserService
    {
        GetUserNameLayoutDataViewModel GetUserNameLayoutData();
        SettingViewModel GetUserNameSettings();
	    void SaveUserSettings(SettingViewModel model);
		void SaveUserInterest(List<IntrestViewModel> intrest);
		void SaveUserNotification(UserCustomNotificationViewModel model);
		void SaveUserSettings(UserCustomSettingsViewModel model);
		List<UserFunctionModel> PrepareDailyWroEventForUsers();
		List<DailyEventsWroFunctionModel> GetDailyWroEvents();
	}
}
