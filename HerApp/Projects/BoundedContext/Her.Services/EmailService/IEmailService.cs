using System.Collections.Generic;
using System.Threading.Tasks;
using Her.ViewModel.MailModels;
using SendGrid;

namespace Her.Services.EmailService
{
    public interface IEmailService
    {
        Task SendTokenAsync(string toEmail, string token);
        Task SendTaskReminderAsync(List<MailTaskReminderViewModel> mailList);
    }
}
