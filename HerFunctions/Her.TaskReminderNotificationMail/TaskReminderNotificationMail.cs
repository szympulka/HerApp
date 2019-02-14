// The 'From' and 'To' fields are automatically populated with the values specified by the binding settings.
//
// You can also optionally configure the default From/To addresses globally via host.config, e.g.:
//
// {
//   "sendGrid": {
//      "to": "user@host.com",
//      "from": "Azure Functions <samples@functions.com>"
//   }
// }
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;

namespace Her.TaskReminderNotificationMail
{
	public static class TaskReminderNotificationMail
	{
		[FunctionName("TaskReminderNotificationMail")]
		public static void Run([QueueTrigger("notificationtaskqueue")]string myQueueItem, TraceWriter log)
		{
			log.Info("done");
			//var mail = Newtonsoft.Json.JsonConvert.DeserializeObject<MailTaskReminderViewModel>(myQueueItem);
			//var message = new SendGridMessage();
			//message.AddTo(mail.UserEmail);
			//message.AddContent("text/html", "sfa");
			//message.SetFrom(new EmailAddress(mail.UserBot + "@her.bot"));
			//message.SetSubject(mail.Subject);
			//return message;
		}
	}

}
