using System;

namespace Her.ViewModel.TasksViewModels
{
    public class UserTaskViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDone { get; set; }
        public TimeSpan? Remind { get; set; }
        public DateTime? TodoDate { get; set; }
        public TimeSpan? TodoHour { get; set; }
    }
}
