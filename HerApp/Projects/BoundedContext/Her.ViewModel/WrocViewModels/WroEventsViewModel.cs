using System;
using System.Collections.Generic;
using System.Text;

namespace Her.ViewModel.WrocViewModels
{
    public class WroEventsViewModel
    {
		public WroEventsViewModel()
		{
			Events = new List<WroEventsListViewModel>();
		}
		public int Count { get; set; }
		public int Page { get; set; }
		public DateTime StartDate { get; set; } = DateTime.Today;
		public IList<WroEventsListViewModel> Events { get; set; }
		public int LastPage { get; set; }
	}
	public class WroEventsListViewModel
	{
		public string PlaceName { get; set; }
		public string Img { get; set; }
		public bool Premiere { get; set; }
		public string Ticketing { get; set; }
		public IEnumerable<string> Categories { get; set; }
		public string Title { get; set; }
		public long WrocItemsId { get; set; }
	}
}
