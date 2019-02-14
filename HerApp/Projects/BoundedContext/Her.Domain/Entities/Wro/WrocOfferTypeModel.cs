using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Wro
{
	[Table("WrocOfferType", Schema = "wro")]
	public class WrocOfferTypeModel
	{
		[Key]
		public virtual long WrocOfferTypeId { get; set; }

		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string LongName { get; set; }
		public virtual string Alias { get; set; }
		public virtual long? WrocOfferId { get; set; }
		[ForeignKey("WrocOfferId")]
		public virtual WrocOfferModel WrocOffer { get; set; }

	}
}
