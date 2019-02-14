using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Dictionaries
{
	[Table("WroCategory", Schema = "Dictionary")]
	public class WroCategoryModel
    {
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual long IntrestId { get; set; }

		[ForeignKey("IntrestId")]
		public virtual IntrestModel Intrest { get; set; }
	}
}
