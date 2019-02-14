using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Her.Context;
using Her.Domain.Entities;
using Her.Repository.Task;
using Her.Repository.User;
using Her.Services.Extensions;
using Her.ViewModel.TasksViewModels;
using Microsoft.EntityFrameworkCore;

namespace Her.Services.TaskService
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private IUserRepository _userRepository;
        private ITaskCategoryRepository _taskCategory;
        private ITaskRepository _taskRepository;
	    private readonly string _currentUser;

		public TaskCategoryService(IUserRepository userRepository, ITaskCategoryRepository taskCategory, ITaskRepository taskRepository, UserResolverService userService)
        {
            _userRepository = userRepository;
            _taskCategory = taskCategory;
            _taskRepository = taskRepository;
	        _currentUser = userService.GetUserName();
		}

		public Tuple<IList<UserTaskCategoryViewModel>, long> GetUserNameTaskCategories(long taskChoosed)
        {

            var list = new List<UserTaskCategoryViewModel>();
			var userId = _userRepository.All().First(y => y.UserName == _currentUser).Id;
			var taskCategoryModels = _taskCategory.All().Where(x =>
                x.UserGuid == userId);

            foreach (var model in taskCategoryModels)
            {
				var utModel = new UserTaskCategoryViewModel()
				{
					Category = model.Name,
					Id = model.Id,
					TaskCount = model.Tasks.Count,
					TaskReadyCout = model.Tasks.Count(x => x.IsDone),
					Task = new List<TaskViewModel>(),
                };
                list.Add(utModel);
            }

            if (taskChoosed != 0)
            {
				List<TaskViewModel> taskViewModelList = new List<TaskViewModel>();
				var task = _taskRepository.All().Where(x => x.TaskCategoryId == taskChoosed);
				foreach (var model in _taskRepository.All().Where(x => x.TaskCategoryId == taskChoosed))
				{
					taskViewModelList.Add(new TaskViewModel()
					{
						CreatedDate = model.CreatedDate,
						IsDone = model.IsDone,
						Name = model.Name,
						Remind = model.Remind,
						TaskCategoryId = model.TaskCategoryId,
						TodoDate = model.TodoDate,
						Id = model.Id,
					});
				}
			  list.Find(x => x.Id == taskChoosed).Task.AddRange(taskViewModelList);
			}
            else if (taskChoosed == 0 && list.Any())
            {
                taskChoosed = list.First().Id;
              // list.First().Task = _taskRepository.All().Where(x => x.TaskCategoryId == taskChoosed);

            }
            return new Tuple<IList<UserTaskCategoryViewModel>, long>(list, taskChoosed);
        }

	    public void AddTaskCategory(string category)
        {
            var task = new TaskCategoryModel()
            {
                Name = category,
                UserGuid = _userRepository.All().First(x => x.UserName == _currentUser).Id,
            };
            _taskCategory.Add(task);
            _taskCategory.SaveChangesAsync();
        }

        public void AddTask(AddTaskViewModel model)
        {
            var taskCategory = _taskCategory.All().First(x => x.Id == model.CategoryId);
            var newTask = new TaskModel()
            {
                CreatedDate = DateTime.Now.AddHours(2),
                IsDone = false,
                Name = model.Name,
                TaskCategoryId = taskCategory.Id,
            };

            if (model.Remind.HasValue) newTask.Remind = TimeSpan.FromMinutes((double)model.Remind);
            if (model.TodoDate != null) newTask.TodoDate = DateTime.ParseExact(model.TodoDate, "MM/dd/yyyy", null);
            if (model.TodoHour != null && newTask.TodoDate.HasValue)
            {
                newTask.TodoDate = newTask.TodoDate.Value.Add(TimeSpan.Parse(model.TodoHour));
            }

            _taskRepository.Add(newTask);
            _taskRepository.SaveChanges();

        }
    }
}
