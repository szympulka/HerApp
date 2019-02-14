using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Dictionaries
{
	[Table("Weather", Schema = "Dictionary")]
	public class WeatherModel
	{
		public virtual long Id { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual string DailySummary { get; set; }
		public virtual string DailyNightSummary { get; set; }
		public virtual DateTime Sunrise { get; set; }
		public virtual DateTime Sunset { get; set; }
		public virtual string Wind { get; set; }
		public virtual string ProbabilityOfRain { get; set; }
		public virtual string MinTemperature { get; set; }
		public virtual string MaxTemperature { get; set; }
	}
}
