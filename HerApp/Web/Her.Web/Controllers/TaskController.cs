using System;
using System.Collections.Generic;
using System.Linq;
using Her.Commons.Enums;
using Her.Services.TaskService;
using Her.ViewModel.TasksViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Her.Web.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskCategoryService _taskCategoryService;
        private readonly ITaskService _taskService;

        public TaskController(ITaskCategoryService taskCategoryService,ITaskService taskService)
        {
            _taskCategoryService = taskCategoryService;
            _taskService = taskService;
        }
        public IActionResult Tasks(long taskChoosed)
        {
			var asdd = HttpContext.Request.Path.Value.Split('/')[1];
            var tasks = _taskCategoryService.GetUserNameTaskCategories(taskChoosed);
            var model = new Tuple<IList<UserTaskCategoryViewModel>, long>(tasks.Item1, tasks.Item2);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddCategoryTask(string name)
        {
            _taskCategoryService.AddTaskCategory(name);
            return RedirectToAction("Tasks");
        }

        [HttpPost]
        public IActionResult AddTask(AddTaskViewModel model)
        {
            _taskCategoryService.AddTask(model);
            return RedirectToAction("Tasks", "Task",new { taskChoosed = model.CategoryId});
        }

        [HttpPost]
        public IActionResult RemoveTask(int id,int categoryId)
        {
            _taskService.RemoveTask(id);
            return RedirectToAction("Tasks", "Task", new { taskChoosed = categoryId });
        }

        public IActionResult ChangeTaskStatus(int id, int categoryId)
        {
            _taskService.ChangeTaskStatus(id);
            return RedirectToAction("Tasks", "Task", new { taskChoosed = categoryId });
        }
    }
}