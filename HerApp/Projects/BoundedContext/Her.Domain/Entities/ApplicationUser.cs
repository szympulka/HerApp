using Her.Domain.Entities.Dictionaries;
using Her.Domain.Entities.ManyToMany;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Her.Domain.Entities
{
    [Table("User",Schema="user")]
    public class ApplicationUser: IdentityUser
    {
        public virtual DateTime? Birthdate { get; set; }
        public virtual string Microsoft { get; set; }
        public virtual string Teams { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual bool IsCreated { get; set; } = false;
        public virtual string BotName { get; set; }
        public virtual string Skype { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime CreatedUTC { get; set; }

        public virtual IEnumerable<TaskCategoryModel> TaskCategory { get; set; }
        public virtual UserCustomNotificationModel CustomNotification { get; set; }
		public virtual UserCustomSettingsModel CustomSettings { get; set; }
		public virtual List<UserInterestModel> Interests { get; set; }
		public virtual List<UserDailyWroEventsModel> DailyWroEvents { get; set; }

	}
}
