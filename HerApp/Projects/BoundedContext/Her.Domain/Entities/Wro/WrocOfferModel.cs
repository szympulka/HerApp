using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Wro
{
	[Table("WrocOffer", Schema = "wro")]
	public class WrocOfferModel
	{
		[Key]
		public virtual long WrocOfferId { get; set; }

		public virtual long Id { get; set; }
		public virtual string Url { get; set; }
		public virtual string Title { get; set; }
		public virtual string Alias { get; set; }
		public virtual string LongDescription { get; set; }
		public virtual string ExternalLink { get; set; }
		public virtual string OfferType { get; set; }
		public virtual string PageLink { get; set; }
		public virtual WrocOfferTypeModel Type { get; set; }
		public virtual WrocMainImageModel MainImage { get; set; }
		public virtual IList<WrocOfferCategoriesModel> Categories { get; set; }
		public virtual long? WrocItemId { get; set; }
		[ForeignKey("WrocItemId")]
		public virtual WrocItemsModel WrocItems { get; set; }

	}
}
