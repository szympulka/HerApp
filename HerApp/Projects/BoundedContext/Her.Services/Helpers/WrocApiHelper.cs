using Her.Domain.Entities.Wro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Her.Services.Helpers
{
	public class WrocApiHelper
	{
		public IList<WrocItemsModel> Items { get; set; }
		public long ListSize { get; set; }
		public int PageSize { get; set; }
		public string Next { get; set; }
	}
}
