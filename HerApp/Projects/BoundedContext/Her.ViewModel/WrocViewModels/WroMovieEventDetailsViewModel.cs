using System;
using System.Collections.Generic;
using System.Text;

namespace Her.ViewModel.WrocViewModels
{
	public class WroMovieEventDetailsViewModel
	{
		public WroMovieEventDetailsViewModel()
		{
			this.MovieDetails = new Dictionary<string, List<WroMovieEventDetailsHelperViewModel>>();
		}
		public string Title { get; set; }
		public string Photo { get; set; }
		public Dictionary<string, List<WroMovieEventDetailsHelperViewModel>> MovieDetails { get; set; }
		public string LongDescription { get; set; }
		public IEnumerable<string> Categories { get; set; }
	}
	public class WroMovieEventDetailsHelperViewModel
	{
		public long Id { get; set; }
		public string Time { get; set; }
		public string PageLink { get; set; }
	}
}
