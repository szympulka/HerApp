using Her.Domain.Entities.ManyToMany;
using Her.Domain.Entities.Wro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Dictionaries
{
	[Table("Interest", Schema = "Dictionary")]
	public class IntrestModel
	{
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }

		public virtual List<UserInterestModel> UserInterests { get; set; }
		public virtual IEnumerable<WroCategoryModel>  WrocCategory {get;set;}
	}
}
