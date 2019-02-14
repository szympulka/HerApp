using Her.Domain.Entities.Wro;
using Her.ViewModel.WrocViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Her.Services.WrocService
{
	public interface IWrocService
	{
		string SaveDailyEventsAsync(string json);
		WroEventsViewModel GetWroEvents(WroEventsViewModel wroc);
		WroEventDetailsViewModel GetWroEventDetails(long wrocItemsId);
		Tuple<Dictionary<string, WroCinemaMovieEventsViewModel>, IEnumerable<string>,string> GetCinemaEvents(DateTime fromDate,string category);
		WroMovieEventDetailsViewModel GetMovieEventDetails(DateTime date, string movie);
	}
}
