using System.IO;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Web;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Her.HttpScheduler
{
	public static class HttpScheduler
	{
		private static readonly HttpClient client = new HttpClient();
		[FunctionName("HttpScheduler")]
		public static async System.Threading.Tasks.Task RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
		{
			string gid = req.GetQueryNameValuePairs()
				 .FirstOrDefault(q => string.Compare(q.Key, "gid", true) == 0)
				 .Value;
			if (gid == "F8CAF77E-36AC-470B-A958-0AEE9D188E16")
			{
				 client.PostAsync("https://herapp.azurewebsites.net/api/Functionality/SendDailyMail", null);
				 client.PostAsync("https://herapp.azurewebsites.net/api/Functionality/SendReminderTask", null);
			     client.PostAsync("https://herapp.azurewebsites.net/api/Functionality/PrepareDailyEvents", null);
			}
			else
			{
				log.Info("Wrong GID");
			}
		}
	}
}
