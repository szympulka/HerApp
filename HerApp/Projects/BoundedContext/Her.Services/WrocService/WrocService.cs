using Her.Repository.Wro;
using Her.Services.Helpers;
using System.Linq;
using Her.Context;
using Her.Domain.Entities.Dictionaries;
using Her.ViewModel.WrocViewModels;
using System.Collections.Generic;
using System;
using Her.Common.Helpers;
using MoreLinq;
namespace Her.Services.WrocService
{
	public class WrocService : IWrocService
	{
		private IWrocItemsRepository _wrocOfferRepository;

		public WrocService(IWrocItemsRepository wroOfferRepository)
		{
			_wrocOfferRepository = wroOfferRepository;
		}

		public Tuple<Dictionary<string, WroCinemaMovieEventsViewModel>, IEnumerable<string>, string> GetCinemaEvents(DateTime fromDate, string category)
		{
			var cinemas = _wrocOfferRepository.All().Where(x => DateTimeHelper.GetToday(x.StartDate) == fromDate && x.IsCinema).Select(x => x.Offer);
			var result = new Dictionary<string, WroCinemaMovieEventsViewModel>();
			var categories = new List<string>();
			foreach (var item in cinemas)
			{
				var itcat = item.Categories.Select(x => x.Name);
				categories.AddRange(itcat);
				if (!itcat.Contains(category) && !string.IsNullOrEmpty(category)) continue;
				if (!result.ContainsKey(item.Title))
				{
					result.Add(item.Title, new WroCinemaMovieEventsViewModel()
					{
						Categories = itcat,
						Photo = item.MainImage != null ? item.MainImage.Large : "https://herapp.azurewebsites.net/images/no-photo.jpg",
					});
				}
			}
			return new Tuple<Dictionary<string, WroCinemaMovieEventsViewModel>, IEnumerable<string>, string>(result, categories.Distinct(), fromDate.ToString("d"));
		}

		public WroMovieEventDetailsViewModel GetMovieEventDetails(DateTime date, string title)
		{
			var moovie = _wrocOfferRepository.All().Where(x => x.Offer.Title == title && DateTimeHelper.GetToday(x.StartDate) == date);
			WroMovieEventDetailsViewModel model;
			if (moovie == null) return null;
			model = new WroMovieEventDetailsViewModel()
			{
				Photo = moovie.First().Offer.MainImage != null ? moovie.First().Offer.MainImage.Large : "https://herapp.azurewebsites.net/images/no-photo.jpg",
				Title = moovie.First().Offer.Title,
				LongDescription = moovie.First().Offer.LongDescription,
				Categories = moovie.First().Offer.Categories.Select(x => x.Name),
			};
			foreach (var item in moovie)
			{
				var helper = new WroMovieEventDetailsHelperViewModel()
				{
					Id = item.Id,
					Time = item.StartDate.ToString("HH:mm"),
					PageLink = item.Offer.PageLink,
				};
				if (!model.MovieDetails.ContainsKey(item.PlaceName))
				{
					model.MovieDetails.Add(item.PlaceName, new List<WroMovieEventDetailsHelperViewModel>());
				}
				model.MovieDetails[item.PlaceName].Add(helper);
			}
			return model;
		}

		public WroEventDetailsViewModel GetWroEventDetails(long wrocItemsId)
		{
			var wroEvent = _wrocOfferRepository.Find(wrocItemsId);
			var model = new WroEventDetailsViewModel()
			{
				PlaceName = wroEvent.PlaceName,
				Premiere = wroEvent.Premiere,
				StartDate = wroEvent.StartDate.ToString("dd MMM HH:mm"),
				EndDate = wroEvent.EndDate.ToString("dd MMM HH:mm"),
				Address = wroEvent.Address.Street,
				Ticketing = wroEvent.Ticketing,
				UrbancardPremium = wroEvent.UrbancardPremium,
				LongDescription = wroEvent.Offer.LongDescription,
				MainImage = wroEvent.Offer.MainImage != null ? wroEvent.Offer.MainImage.Large : "https://herapp.azurewebsites.net/images/no-photo.jpg",
				MainImageDescription = wroEvent.Offer.MainImage.Description,
				Title = wroEvent.Offer.Title,
				PageLink = wroEvent.Offer.PageLink,
				TypeName = wroEvent.Offer.Type.Name,
				Categories = wroEvent.Offer.Categories.Select(x => x.Name),
				ExternalLink = wroEvent.Offer.ExternalLink,
			};
			return model;
		}

		public WroEventsViewModel GetWroEvents(WroEventsViewModel wroc)
		{
			var wrocEvents = _wrocOfferRepository.All().Where(x => DateTimeHelper.GetToday(x.StartDate) >= wroc.StartDate && DateTimeHelper.GetToday(x.EndDate) <= wroc.StartDate && !x.IsCinema).AsQueryable();
			wroc.Count = wrocEvents.Count();
			wroc.LastPage = (int)(wroc.Count / 15);
			wrocEvents = wrocEvents.Skip(wroc.Page * 15).Take(15);
			foreach (var item in wrocEvents)
			{
				wroc.Events.Add(new WroEventsListViewModel()
				{
					PlaceName = item.PlaceName,
					WrocItemsId = item.WrocItemsId,
					Img = item.Offer.MainImage != null ? item.Offer.MainImage.Large : "https://herapp.azurewebsites.net/images/no-photo.jpg",
					Premiere = item.Premiere,
					Ticketing = item.Ticketing,
					Title = item.Offer.Title,
					Categories = item.Offer.Categories.Select(x => x.Name),
				});
			}
			return wroc;
		}

		public string SaveDailyEventsAsync(string json)
		{
			var list = new List<WroCategoryModel>();
			var model = Newtonsoft.Json.JsonConvert.DeserializeObject<WrocApiHelper>(json);
			foreach (var item in model.Items)
			{
				var asd = _wrocOfferRepository.All().FirstOrDefault(x => x.Id == item.Id);
				if (_wrocOfferRepository.All().FirstOrDefault(x => x.Id == item.Id) == null)
				{
					if (item.PlaceName.ToLower().Contains("cinema")
						|| item.PlaceName.ToLower().Contains("kino")
						|| item.PlaceName.ToLower().Contains("multikino")
						|| item.PlaceName.ToLower().Contains("helios")
						|| item.PlaceName.ToLower().Contains("dcf"))
					{
						item.IsCinema = true;
					}
					_wrocOfferRepository.Add(item);
					foreach (var aa in item.Offer.Categories.Select(x => x.Name))
					{
						list.Add(new WroCategoryModel()
						{
							Name = aa,
							IntrestId = 4,
						});
					}

				}
			}
			///TODO: Lol
			using (var db = new HerContext())
			{
				foreach (var item in list.Distinct())
				{
					if (db.WroCategories.FirstOrDefault(x => x.Name == item.Name) == null)
					{
						db.WroCategories.Add(item);
					}
				}
				db.SaveChanges();
			}
			_wrocOfferRepository.SaveChanges();
			return model.Next;
		}
	}
}
