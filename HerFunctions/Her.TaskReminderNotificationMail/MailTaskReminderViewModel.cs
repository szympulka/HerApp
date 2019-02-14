using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Her.TaskReminderNotificationMail
{
	public class MailTaskReminderViewModel
	{
		public List<TaskReminderHerlper> TaskReminderHerlpers { get; set; }
		public string CategoryName { get; set; }
		public string UserEmail { get; set; }
		public string UserBot { get; set; }
		public string Subject { get; internal set; }
	}

	public class TaskReminderHerlper
	{
		public DateTime TodoDate { get; set; }
		public TimeSpan Remind { get; set; }

		public string Name { get; set; }
	}
}
