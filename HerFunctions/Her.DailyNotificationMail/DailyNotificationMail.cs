using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Her.DailyNotificationMail
{
    public static class DailyNotificationMail
    {
		[FunctionName("DailyNotificationMail")]
		public static void Run([QueueTrigger("notificationmailqueue")]string myQueueItem, TraceWriter log)
		{
		}
	}
}
