using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Wro
{
	[Table("WrocMainImage", Schema = "wro")]
	public class WrocMainImageModel
	{
		[Key]
		public virtual long WrocMainImageId { get; set; }
		public virtual string Standard { get; set; }
		public virtual string Large { get; set; }
		public virtual string Thumbnail { get; set; }
		public virtual string Tile { get; set; }
		public virtual string Banner { get; set; }
		public virtual string Description { get; set; }
		public virtual long? WrocOfferId { get; set; }
		[ForeignKey("WrocOfferId")]
		public virtual WrocOfferModel WrocOffer { get; set; }
	}
}
