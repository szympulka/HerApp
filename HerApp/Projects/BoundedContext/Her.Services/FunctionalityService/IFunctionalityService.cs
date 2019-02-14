using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Her.ViewModel.MailModels;

namespace Her.Services.FunctionalityService
{
    public interface IFunctionalityService
    {
		List<MailTaskReminderViewModel> GetReminderTask();
        List<MailTaskReminderViewModel> GetDailyMail();
    }
}
