using System.Collections.Generic;
using System.Linq;
using Her.Commons.Enums;

namespace Her.ViewModel.TasksViewModels
{
    public class UserTaskCategoryViewModel
    {
        public string Category { get; set; }
        public int TaskCount { get; set; }
        public int TaskReadyCout { get; set; }
        public List<TaskViewModel> Task { get; set; }
        public long Id { get; set; }
    }


}
