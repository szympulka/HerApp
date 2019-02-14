using System.ComponentModel.DataAnnotations;

namespace Her.ViewModel.TasksViewModels
{
    public class AddTaskViewModel
    {
        [Required]
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public string TodoDate { get; set; }
        public string TodoHour { get; set; }
        public int? Remind { get; set; }
    }
}
