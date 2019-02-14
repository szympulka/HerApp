using System.Collections.Generic;
using System.Threading.Tasks;
using Her.Commons.Consts.Services;
using Her.ViewModel.MailModels;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Her.Services.EmailService
{
    public class EmailService: IEmailService
    {
        private async Task CreateMailAsync(string toEmail, string fromEmail,string mailName, string subject, string plainText, string content)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, mailName);
            var to = new EmailAddress(toEmail);
            //    var plainTextContent = Regex.Replace("sadasd", "<[^>]*>", "");
            var plainTextContent = plainText;
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }

        public async Task SendTokenAsync(string toEmail,string token)
        {
            var content = "Your token bro!  <p>" + token + "</p>" ;

            await CreateMailAsync(toEmail,"her@her.bot","HerBot", EmailConsts.TokenSubject,"HerBot",content);
        }

        public async Task SendTaskReminderAsync(List<MailTaskReminderViewModel> mailList)
        {
            foreach (var mail in mailList)
            {
                var content = "Its your tasks! \n ";
                foreach (var cont in mail.TaskReminderHerlpers)
                {
                    content += "<p>"+ cont.Remind.Minutes + " minutes to" +  cont.Name + "task: Time TODO" +cont.TodoDate.ToString("HH:mm") + " " + " </p>";
                }

                await CreateMailAsync(mail.UserEmail, mail.UserBot + "@her.bot", mail.UserBot,EmailConsts.TaskReminderSubject, "HerBot", content);

            }
        }
    }
}
