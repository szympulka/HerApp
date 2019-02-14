using Her.Domain.Entities.Wro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities
{
	[Table("UserDailyWroEvents", Schema = "User")]
	public class UserDailyWroEventsModel
    {
		[Key, Column(Order = 0)]
		public virtual string UserID { get; set; }
		[Key, Column(Order = 1)]
		public virtual long WrocItemsID { get; set; }

		[ForeignKey("UserID")]
		public virtual ApplicationUser User { get; set; }
		[ForeignKey("WrocItemsID")]
		public virtual WrocItemsModel WrocItems { get; set; }

	}
}
