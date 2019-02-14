using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Dictionaries
{
	[Table("MPKInfo", Schema = "Dictionary")]
	public class MPKInfoModel
    {
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public string Content { get; set; }
    }
}
