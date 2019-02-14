using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Wro
{
	[Table("WrocOfferAdresss", Schema = "wro")]
	public class WrocOfferAdressModel
    {
		[Key]
		public virtual long WrocOfferAdressId { get; set; }
		public virtual string City { get; set; }
		public virtual string Street { get; set; }
		public virtual string ZipCode { get; set; }

		public virtual long? WrocItemId { get; set; }
		[ForeignKey("WrocItemId")]
		public virtual WrocItemsModel WrocItems { get; set; }
	}
}
