using System;
using System.Collections.Generic;
using System.Text;

namespace Her.Common.Extensions
{
    public static class DateTimeExtensions
    {
		public static string TodayExtension(this DateTime date)
		{
			return DateTime.Now.ToString("m");
		}
    }
}
