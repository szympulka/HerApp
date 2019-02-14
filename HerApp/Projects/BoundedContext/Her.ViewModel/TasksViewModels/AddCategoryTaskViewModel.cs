using System.Collections.Generic;

namespace Her.ViewModel.TasksViewModels
{
    public class AddCategoryTaskViewModel
    {
        public string Name { get; set; }
        public List<UserTaskViewModel> Tasks { get; set; }
    }
}
