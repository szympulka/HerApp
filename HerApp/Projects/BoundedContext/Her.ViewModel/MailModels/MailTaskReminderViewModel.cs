using Her.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Her.ViewModel.MailModels
{
    public class MailTaskReminderViewModel
    {
        public List<TaskReminderHerlper> TaskReminderHerlpers { get; set; }
        public string CategoryName { get; set; }
        public string UserEmail { get; set; }
        public string UserBot { get; set; }
		public string Subject { get; set; }
	}

    public class TaskReminderHerlper
    {
        public DateTime TodoDate { get; set; }
        public TimeSpan Remind { get; set; }

        public string Name { get; set; }
    }
}
