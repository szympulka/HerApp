using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Her.ViewModel.MailModels;

namespace Her.Services.AzureServices
{
    public interface IQueueServcie
    {
	    void AddMailsToMailNotification();
	    void AddRemindTaskToQueue(List<MailTaskReminderViewModel> daily);
    }
}
