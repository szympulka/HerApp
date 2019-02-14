using System;
using System.Collections.Generic;
using System.Text;

namespace Her.FunctionsViewModel.DailyWroEventFunction
{
	public class DailyEventsWroFunctionModel
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string PlaceName { get; set; }
		public bool Premiere { get; set; }
		public IEnumerable<string> Categories { get; set; }
		public string MainImage { get; set; }
		public string PageLink { get; set; }
		public string ExternalLink { get; set; }
	}
}
