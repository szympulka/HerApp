using System;
using System.Collections.Generic;
using System.Text;

namespace Her.ViewModel.DashboardViewModels
{
	public class DashboardViewModel
	{
		public IList<DashboardTaskViewModel> Tasks { get; set; }
		public WeatherDashboard Weather { get; set; }
		public List<MPK> Mpk { get; set; }
		public bool AccuntsIsAvaible { get; set; } = true;
		public bool UserDataIsAvailbe { get; set; } = true;
		public bool BotNameIsAvaiblea { get; set; } = true;
		public int UserSettingCount { get; set; } = 3;
	}
	public class WeatherDashboard
	{
		public DateTime Date { get; set; }
		public string DailySummary { get; set; }
		public string DailyNightSummary { get; set; }
		public DateTime Sunrise { get; set; }
		public DateTime Sunset { get; set; }
		public string Wind { get; set; }
		public string ProbabilityOfRain { get; set; }
		public string MaxTemperature { get; set; }
		public string MinTemperature { get; set; }
	}
	public class MPK
	{
		public DateTime DateAdded { get; set; }
		public string Content { get; set; }
	}
}
