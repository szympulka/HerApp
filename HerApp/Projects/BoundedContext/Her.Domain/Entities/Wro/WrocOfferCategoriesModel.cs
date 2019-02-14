using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Wro
{
	[Table("WrocOfferCategories", Schema = "wro")]
	public class WrocOfferCategoriesModel
    {
		[Key]
		public virtual long WrocOfferCategoriesId { get; set; }
		public virtual long Id { get; set; }
		public virtual long? WrocOfferId { get; set; }
		public virtual string Name { get; set; }
		public virtual string LongName { get; set; }
		public virtual string Alias { get; set; }
		[ForeignKey("WrocOfferId")]
		public virtual WrocOfferModel User { get; set; }

	}
}
