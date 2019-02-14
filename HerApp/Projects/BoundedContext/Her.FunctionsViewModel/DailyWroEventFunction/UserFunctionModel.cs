using System;
using System.Collections.Generic;
using System.Text;

namespace Her.FunctionsViewModel.DailyWroEventFunction
{
    public class UserFunctionModel
    {
		public string Id { get; set; }
		public string UserName { get; set; }
		public List<string> InterestCategories { get; set; }
		public int DailyWroEventCount { get; set; }
	}

}
