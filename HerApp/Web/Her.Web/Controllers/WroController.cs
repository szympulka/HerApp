using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Her.Services.WrocService;
using Her.ViewModel.WrocViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;

namespace Her.Web.Controllers
{
	[Authorize]
	public class WroController : Controller
	{
		private IWrocService _wrocService;
		public WroController(IWrocService wrocService)
		{
			_wrocService = wrocService;
		}
		public IActionResult GetWroEvents([FromQuery]int page, DateTime? fromDate)
		{
			var model = new WroEventsViewModel()
			{
				Page = page,
			};
			if (fromDate != null)
			{
				model.StartDate = fromDate.Value;
			}
			var wmodel = _wrocService.GetWroEvents(model);
			return View(wmodel);
		}
		[Route("GetWroEventDetails")]
		public IActionResult GetWroEventDetails([FromQuery]long WrocItemsId)
		{
			var model =_wrocService.GetWroEventDetails(WrocItemsId);
			return View(model);
		}
		public IActionResult GetCinemaEvents(string Date, string Category)
		{
			Tuple<Dictionary<string, WroCinemaMovieEventsViewModel>, IEnumerable<string>,string> model;
			if (string.IsNullOrEmpty(Date))
			{
				model = _wrocService.GetCinemaEvents(DateTime.Today,Category);
			}
			else
			{
				model = _wrocService.GetCinemaEvents(DateTime.Parse(Date),Category);
			}
			return View(model);
		}
		public IActionResult GetMovieEventDetails([FromQuery] string date,string movie)
		{
			var model = _wrocService.GetMovieEventDetails(DateTime.Parse(date), movie);
			return View(model);
		}
	}
}