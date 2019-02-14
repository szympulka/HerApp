using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Her.Repository.Task;
using Her.Services.EmailService;
using Her.ViewModel.MailModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Her.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void RemoveTask(int id)
        {
            var task = _taskRepository.All().FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                _taskRepository.Remove(task);
                _taskRepository.SaveChanges();
            }
        }

        public void ChangeTaskStatus(int id)
        {
            var task = _taskRepository.All().FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                task.IsDone = !task.IsDone;
                _taskRepository.Update(task);
                _taskRepository.SaveChanges();
            }
        }
    }
}

