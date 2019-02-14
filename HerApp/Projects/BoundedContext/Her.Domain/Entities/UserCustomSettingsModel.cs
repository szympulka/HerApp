using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities
{
	[Table("UserCustomSettings", Schema = "user")]

	public class UserCustomSettingsModel
    {
		public virtual long Id { get; set; }
		public virtual bool DailyWroEvent { get; set; } = true;
		public virtual bool DailyWeather { get; set; } = true;
		public virtual bool DailyMpkInfo { get; set; } = true;
		public virtual string UserID { get; set; }
		[ForeignKey("UserID")]
		public virtual ApplicationUser User { get; set; }

	}
}
