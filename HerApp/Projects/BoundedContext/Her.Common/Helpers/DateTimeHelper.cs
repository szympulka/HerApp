using System;
using System.Collections.Generic;
using System.Text;

namespace Her.Common.Helpers
{
    public static class DateTimeHelper
    {
		public static DateTime GetToday(this DateTime date)
		{
			return DateTime.Parse(date.ToString("d"));
		}
    }
}
