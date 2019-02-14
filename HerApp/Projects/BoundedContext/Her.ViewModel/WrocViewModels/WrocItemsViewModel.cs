using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Her.ViewModel.WrocAPI
{
	public class WrocApiHelper
	{
		public IList<WrocItemsViewModel> Items { get; set; }
		public long ListSize { get; set; }
		public int PageSize { get; set; }
		public string Next { get; set; }
	}
	public class WrocItemsViewModel
	{
		public Offer Offer { get; set; }
		public Address Address { get; set; }
		public bool UrbancardPremium { get; set; }
		public string PlaceName { get; set; }
		public bool Premiere { get; set; }
		public string Ticketing { get; set; }
	}

	public class TypeModel
	{
		public string Name { get; set; }
		public string LongName { get; set; }
		public string Alias { get; set; }
		public string Language { get; set; }
	}
	public class Categories
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LongName { get; set; }
		public string Alias { get; set; }
	}
	public class MainImage
	{
		public string Standard { get; set; }
		public string Large { get; set; }
		public string Thumbnail { get; set; }
		public string Tile { get; set; }
		public string Banner { get; set; }
		public string Description { get; set; }
	}
	public class Offer
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public string Alias { get; set; }
		public string LongDescription { get; set; }
		public string ExternalLink { get; set; }
		public string OfferType { get; set; }
		public string PageLink { get; set; }
		public TypeModel Type { get; set; }
		public IList<Categories> Categories { get; set; }
		public MainImage MainImage { get; set; }

	}
	public class Address
	{
		public string City { get; set; }
		public string Street { get; set; }
		public string ZipCode { get; set; }
	}
}
