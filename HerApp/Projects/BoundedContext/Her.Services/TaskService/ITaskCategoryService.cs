using System;
using System.Collections.Generic;
using System.Text;
using Her.ViewModel.TasksViewModels;

namespace Her.Services.TaskService
{
    public interface ITaskCategoryService
    {
        Tuple<IList<UserTaskCategoryViewModel>,long> GetUserNameTaskCategories(long taskChoosed);
        void AddTaskCategory(string category);
        void AddTask(AddTaskViewModel model);
    }
}
