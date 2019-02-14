using System;
using System.Collections.Generic;
using System.Text;

namespace Her.ViewModel.WrocViewModels
{
    public class WroCinemaEventsViewModel
    {
		public string Title { get; set; }
		public string Img { get; set; }
		public List<WroCinemaEventsHeleprViewModel> Details { get; set; }
	}
	public class WroCinemaEventsHeleprViewModel
	{
		public DateTime StartDate { get; set; }
		public long Id { get; set; }
		public string CinemaName { get; set; }
	}
}
