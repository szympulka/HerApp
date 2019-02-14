using System;
using System.Collections.Generic;
using System.Text;

namespace Her.ViewModel.TasksViewModels
{
    public class TaskViewModel
    {
		public long Id { get; set; }
		public long TaskCategoryId { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? TodoDate { get; set; }
		public TimeSpan? Remind { get; set; }
		public bool IsDone { get; set; }

	}
}
