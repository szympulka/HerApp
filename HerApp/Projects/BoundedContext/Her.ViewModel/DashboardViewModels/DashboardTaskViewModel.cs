using System;

namespace Her.ViewModel.DashboardViewModels
{
    public class DashboardTaskViewModel
    {
        public long Id { get; set; }
        public long CategorId { get; set; }
        public TimeSpan TodoTime { get; set; }
        public string Name { get; set; }
    }
}
