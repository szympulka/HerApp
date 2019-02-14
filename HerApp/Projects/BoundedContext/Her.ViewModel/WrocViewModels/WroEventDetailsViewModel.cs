using System;
using System.Collections.Generic;
using System.Text;

namespace Her.ViewModel.WrocViewModels
{
	public class WroEventDetailsViewModel
	{
		public string PlaceName { get; set; }
		public bool Premiere { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string Address { get; set; }
		public string Ticketing { get; set; }
		public bool UrbancardPremium { get; set; }
		public string LongDescription { get; set; }
		public string MainImage { get; set; }
		public string Title { get; set; }
		public string PageLink { get; set; }
		public string TypeName { get; set; }
		public IEnumerable<string> Categories { get; set; }
		public string ExternalLink { get; set; }
		public string MainImageDescription { get; set; }
	}
}
