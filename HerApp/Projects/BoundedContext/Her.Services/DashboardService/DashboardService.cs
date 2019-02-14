using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Her.Common.Helpers;
using Her.Repository.Dictionary;
using Her.Repository.Task;
using Her.Repository.User;
using Her.Services.Extensions;
using Her.ViewModel.DashboardViewModels;
using Microsoft.EntityFrameworkCore;

namespace Her.Services.DashboardService
{
	public class DashboardService : IDashboardService
	{
		private ITaskCategoryRepository _taskCategoryRepository;
		private IUserRepository _userRepository;
		private readonly string _currentUser;
		private readonly IWeatherRepository _weatherRepository;
		private readonly IMPKInfoRepository _mpkInfoRepository;

		public DashboardService(ITaskCategoryRepository taskCategoryRepository, IUserRepository userRepository, UserResolverService userService, IWeatherRepository weather, IMPKInfoRepository mpkInfo)
		{
			_taskCategoryRepository = taskCategoryRepository;
			_userRepository = userRepository;
			_currentUser = userService.GetUserName();
			_weatherRepository = weather;
			_mpkInfoRepository = mpkInfo;
		}

		public DashboardViewModel GetUserNameDashboard()
		{
			var model = new DashboardViewModel();
			var categoryTask = _taskCategoryRepository.All().Where(x => x.User.UserName == _currentUser);
			var user = _userRepository.All().First(x => x.UserName == _currentUser);

			#region UserTasks
			var dTaskViewModel = new List<DashboardTaskViewModel>();
			foreach (var tasks in categoryTask.Select(x => x.Tasks))
			{
				foreach (var task in tasks.Where(x => x.TodoDate.HasValue && !x.IsDone))
				{
					var todoHelper = (task.TodoDate.Value - DateTime.Now);
					if (dTaskViewModel.Any(x => x.TodoTime > todoHelper) && dTaskViewModel.Count > 8) continue;
					dTaskViewModel.Add(new DashboardTaskViewModel()
					{
						Id = task.Id,
						Name = task.Name,
						CategorId = task.TaskCategoryId,
						TodoTime = todoHelper.Add(TimeSpan.FromHours(-2)),
					});
				}

			}
			model.Tasks = dTaskViewModel.Take(8).OrderBy(x => x.TodoTime).ToList();
			#endregion

			#region UserSettings
			if (!user.IsCreated)
			{
				if (string.IsNullOrEmpty(user.Microsoft) && string.IsNullOrEmpty(user.Skype) && string.IsNullOrEmpty(user.Teams))
				{
					model.AccuntsIsAvaible = false;
					model.UserSettingCount--;
				}
				if (string.IsNullOrEmpty(user.Surname) || string.IsNullOrEmpty(user.Name))
				{
					model.UserDataIsAvailbe = false;
					model.UserSettingCount--;

				}
				if (string.IsNullOrEmpty(user.BotName))
				{
					model.BotNameIsAvaiblea = false;
					model.UserSettingCount--;
				}
			}
			#endregion

			#region Weather
			if (user.CustomSettings.DailyWeather)
			{
				var wet = _weatherRepository.All().First(x => DateTimeHelper.GetToday(x.Sunset) == DateTime.Today);
				model.Weather = new WeatherDashboard()
				{
					Date = wet.Date,
					DailyNightSummary = wet.DailyNightSummary,
					DailySummary = wet.DailySummary,
					ProbabilityOfRain = wet.ProbabilityOfRain,
					Sunrise = wet.Sunrise,
					Sunset = wet.Sunset,
					Wind = wet.Wind,
					MinTemperature = wet.MinTemperature,
					MaxTemperature = wet.MaxTemperature
				};
			}
			#endregion

			#region MPK
			if (user.CustomSettings.DailyWeather)
			{
				model.Mpk = new List<MPK>();				
				foreach (var item in _mpkInfoRepository.All().Where(x => DateTimeHelper.GetToday(x.DateCreated) == DateTime.Today).OrderByDescending(x => x.DateCreated))
				{
					model.Mpk.Add(new MPK
					{
						Content = item.Content,
						DateAdded = item.DateCreated,
					});
				};
			}
			#endregion


			return model;
		}
	}
}
