using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Her.Common.Enums;
using Her.Domain.Entities;
using Her.Domain.Entities.Dictionaries;
using Her.Domain.Entities.ManyToMany;
using Her.FunctionsViewModel;
using Her.FunctionsViewModel.DailyWroEventFunction;
using Her.Repository.User;
using Her.Repository.Wro;
using Her.Services.Extensions;
using Her.ViewModel;
using Her.ViewModel.UserViewModels;
using Microsoft.AspNetCore.Identity;



namespace Her.Services.UserService
{
	public class UserService : IUserService
	{
		private IWrocItemsRepository _wrocItems;
		private IUserRepository _userRepository;
		private readonly string _currentUser;
		public UserService(IUserRepository repository, UserResolverService userService, IWrocItemsRepository wrocItems)
		{
			_wrocItems = wrocItems;
			_userRepository = repository;
			_currentUser = userService.GetUserName();
		}
		private ApplicationUser SaveOrUpdate(ApplicationUser user)
		{
			if (string.IsNullOrEmpty(user.Id))
			{
				_userRepository.Add(user);
				_userRepository.SaveChanges();
			}
			else
			{
				_userRepository.Update(user);
				_userRepository.SaveChanges();
			}
			return user;
		}
		public GetUserNameLayoutDataViewModel GetUserNameLayoutData()
		{
			var user = _userRepository.All().First(x => x.UserName == _currentUser);
			var userLayout = new GetUserNameLayoutDataViewModel()
			{
				BotName = user.BotName,
				Name = user.Name,
				Surname = user.Surname,
				PersonData = user.Name + " " + user.Surname,
			};
			return userLayout;
		}

		public SettingViewModel GetUserNameSettings()
		{
			var user = _userRepository.All().First(x => x.UserName == _currentUser);

			var model = new SettingViewModel()
			{
				Name = user.Name,
				Surname = user.Surname,
				Skype = user.Skype,
				Microsoft = user.Microsoft,
				Birthdate = user.Birthdate?.ToString("d"),
				BotName = user.BotName,
				Teams = user.Teams,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				IsCreated = user.IsCreated,
				UserIntrest = user.Interests.Select(x => x.Intrest.Name).ToList(),
			};
			model.CustomNotifications = new UserCustomNotificationViewModel()
			{
				NotificationEvent = user.CustomNotification != null ? user.CustomNotification.NotificationEvent : false,
				NotificationTask = user.CustomNotification != null ? user.CustomNotification.NotificationTask : false,
				NotificationWeather = user.CustomNotification != null ? user.CustomNotification.NotificationWeather : false,
				RememberTime = user.CustomNotification != null ? user.CustomNotification.RememberTime : TimeSpan.Zero,
				IsActive = user.CustomNotification != null ? user.CustomNotification.IsActive : false,
			};
			model.CustomSettings = new UserCustomSettingsViewModel()
			{
				DailyWroEvent = user.CustomSettings != null ? user.CustomSettings.DailyWroEvent : false,
				DailyMpkInfo = user.CustomSettings != null ? user.CustomSettings.DailyMpkInfo : false,
				DailyWeather = user.CustomSettings != null ? user.CustomSettings.DailyWeather : false,

			};

			return model;
		}

		public void SaveUserSettings(SettingViewModel model)
		{
			var user = _userRepository.All().First(x => x.UserName == _currentUser);
			if (!string.IsNullOrEmpty(model.Birthdate))
			{
				user.Birthdate = DateTime.Parse(model.Birthdate);
			}
			user.BotName = model.BotName;
			user.Microsoft = model.Microsoft;
			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Teams = model.Teams;
			user.Skype = model.Skype;
			user.IsCreated = false;
			user.PhoneNumber = model.PhoneNumber;

			if (!string.IsNullOrEmpty(user.Microsoft) || !string.IsNullOrEmpty(user.Skype) ||
				!string.IsNullOrEmpty(user.Teams) ||
				(!string.IsNullOrEmpty(user.Surname) || !string.IsNullOrEmpty(user.Name)) &&
				!string.IsNullOrEmpty(user.BotName))
			{
				user.IsCreated = true;
			}

			this.SaveOrUpdate(user);
		}

		public void SaveUserInterest(List<IntrestViewModel> intrest)
		{
			var user = _userRepository.All().First(x => x.UserName == _currentUser);
			foreach (var item in intrest)
			{
				if (user.Interests.Count() != 0)
				{
					var model = user.Interests.FirstOrDefault(x => x.IntrestID == item.Id);
					if (model == null && item.IsTrue)
					{
						user.Interests.Add(new UserInterestModel()
						{
							IntrestID = item.Id,
							UserID = user.Id,
						});
					}
					else if (model != null && !item.IsTrue)
					{
						user.Interests.Remove(model);
					}
				}
				else
				{
					if (item.IsTrue)
					{
						user.Interests.Add(new UserInterestModel()
						{
							IntrestID = item.Id,
							UserID = user.Id,
						});
					}
				}
			}
			this.SaveOrUpdate(user);
		}

		public void SaveUserNotification(UserCustomNotificationViewModel model)
		{
			var user = _userRepository.All().First(x => x.UserName == _currentUser);
			if (user.CustomNotification == null)
			{
				user.CustomNotification = new UserCustomNotificationModel();
			}
			user.CustomNotification.IsActive = model.IsActive;
			user.CustomNotification.RememberTime = model.RememberTime;
			user.CustomNotification.NotificationWeather = model.NotificationWeather;
			user.CustomNotification.NotificationTask = model.NotificationTask;
			user.CustomNotification.NotificationEvent = model.NotificationEvent;
			user.CustomNotification.RememberTime = model.RememberTime;
			this.SaveOrUpdate(user);
		}

		public void SaveUserSettings(UserCustomSettingsViewModel model)
		{
			var user = _userRepository.All().First(x => x.UserName == _currentUser);
			if (user.CustomSettings == null)
			{
				user.CustomSettings = new UserCustomSettingsModel();
			}
			user.CustomSettings.DailyWroEvent = model.DailyWroEvent;
			user.CustomSettings.DailyWeather = model.DailyWeather;
			user.CustomSettings.DailyMpkInfo = model.DailyMpkInfo;

			this.SaveOrUpdate(user);

		}

		public List<UserFunctionModel> PrepareDailyWroEventForUsers()
		{
			//var list = new List<UserFunctionModel>();
			//var users = _userRepository.All().Where(x => x.CustomSettings.DailyWroEvent);
			//foreach (var user in users)
			//{
			//	var model = new UserFunctionModel()
			//	{
			//		Id = user.Id,
			//		UserName = user.UserName,
			//		InterestCategories = new List<string>(),
			//		DailyWroEventCount = user.CustomSettings.DailyWroEventCount,

			//	};
			//	foreach (var item in user.Interests.Select(x => x.Intrest.WrocCategory.Select(y => y.Name)))
			//	{
			//		model.InterestCategories.AddRange(item.ToList());
			//	}
			//	list.Add(model);
			//}
			//return list;
			return null;
		}

		public List<DailyEventsWroFunctionModel> GetDailyWroEvents()
		{
			var list = new List<DailyEventsWroFunctionModel>();
			foreach (var item in _wrocItems.All().Where(x => x.EndDate >= DateTime.Today && x.StartDate <= DateTime.Today))
			{
				list.Add(new DailyEventsWroFunctionModel()
				{
					StartDate = item.StartDate,
					EndDate = item.EndDate,
					PlaceName = item.PlaceName,
					Premiere = item.Premiere,
					Categories = item.Offer.Categories.Select(x=> x.Name),
					MainImage = item.Offer.MainImage.Standard,
					PageLink = item.Offer.PageLink,
					ExternalLink = item.Offer.ExternalLink,
				});
			}
			return list;
		}
	}
}
