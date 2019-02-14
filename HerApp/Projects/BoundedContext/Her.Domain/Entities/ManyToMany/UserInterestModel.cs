using Her.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.ManyToMany
{
	[Table("UserInterest", Schema = "User")]
	public class UserInterestModel
	{
		[Key, Column(Order = 0)]
		public virtual string UserID { get; set; }
		[Key, Column(Order = 1)]
		public virtual long IntrestID { get; set; }

		[ForeignKey("UserID")]
		public virtual ApplicationUser User { get; set; }
		[ForeignKey("IntrestID")]
		public virtual IntrestModel Intrest { get; set; }

	}
}
