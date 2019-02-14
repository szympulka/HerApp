using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Her.Common.Enums;
using Her.Repository.Task;
using Her.Services.EmailService;
using Her.ViewModel.MailModels;
using Microsoft.EntityFrameworkCore;

namespace Her.Services.FunctionalityService
{
    public class FunctionalityService : IFunctionalityService
    {
        private ITaskRepository _taskRepository;
        private IEmailService _emailService;

        public FunctionalityService(ITaskRepository taskRepository, IEmailService emailService)
        {
            _taskRepository = taskRepository;
            _emailService = emailService;
        }

	    public List<MailTaskReminderViewModel> GetReminderTask()
	    {
			var mailList = new List<MailTaskReminderViewModel>();
			var tasks = _taskRepository.All().Where(x =>
				x.TodoDate.HasValue && x.Remind.HasValue && x.TodoDate <= DateTime.Now.AddDays(1) &&
				x.TodoDate >= DateTime.Now.AddDays(-2) && !x.IsDone);

			foreach (var id in tasks.Select(x => x.TaskCategoryId).Distinct())
			{
				var taskList = new List<TaskReminderHerlper>();
				var mm = new MailTaskReminderViewModel()
				{
					//ReSharper disable once PossibleInvalidOperationException
					CategoryName = tasks.First(x => x.TaskCategoryId == id).TaskCategory.Name,
					UserEmail = tasks.First(x => x.TaskCategoryId == id).TaskCategory.User.Email,
					//ReSharper disable once PossibleInvalidOperationException
					UserBot = tasks.First(x => x.TaskCategoryId == id).TaskCategory.User.BotName,
					Subject = "Task Reminder"
				};
				foreach (var task in tasks.Where(x => x.TaskCategoryId == id))
				{
					// ReSharper disable once PossibleInvalidOperationException
					if (DateTime.Now.AddHours(2).Add(task.Remind.Value) <= task.TodoDate.Value) continue;
					var totalMinutes = (DateTime.Now.AddHours(2).Add(task.Remind.Value) - task.TodoDate.Value).TotalMinutes;
					if (totalMinutes > 0 && totalMinutes <= 15)
					{
						// ReSharper disable once PossibleInvalidOperationException
						taskList.Add(new TaskReminderHerlper()
						{
							// ReSharper disable once PossibleInvalidOperationException
							TodoDate = task.TodoDate.Value,
							// ReSharper disable once PossibleInvalidOperationException
							Remind = task.Remind.Value,
							Name = task.Name
						});
					}
				}
				if (!taskList.Any()) continue;
				if (mailList.FirstOrDefault(x => x.UserEmail == mm.UserEmail) == null)
				{
					mm.TaskReminderHerlpers = taskList;
					mailList.Add(mm);
				}
				else
				{
					mailList.First(x => x.UserEmail == mm.UserEmail).TaskReminderHerlpers.AddRange(taskList);
				}

			}
			return mailList;
		}

	    public List<MailTaskReminderViewModel> GetDailyMail()
	    {
		    return null;
	    }


    }
}
