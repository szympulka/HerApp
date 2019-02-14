using Her.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Her.Domain.Entities.Wro
{
	[Table("WrocItems", Schema = "wro")]
	public class WrocItemsModel
	{
		[Key]
		public virtual long WrocItemsId { get; set; }
		public virtual long Id { get; set; }
		public virtual bool UrbancardPremium { get; set; }
		public virtual string PlaceName { get; set; }
		public virtual bool Premiere { get; set; }
		public virtual string Ticketing { get; set; }
		public virtual DateTime StartDate { get; set; }
		public virtual DateTime EndDate { get; set; }
		public virtual bool IsCinema { get; set; }

		public virtual WrocOfferAdressModel Address { get; set; }
		public virtual WrocOfferModel Offer { get; set; }
		public virtual List<UserDailyWroEventsModel> UserDailyWroEvents { get; set; }

	}
}
