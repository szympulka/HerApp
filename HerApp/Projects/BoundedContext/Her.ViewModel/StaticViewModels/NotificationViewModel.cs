using System;
using System.Collections.Generic;
using System.Text;
using Her.Commons.Enums;

namespace Her.ViewModel.StaticViewModels
{
    public class NotificationViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public NotificationImportantValueEnum ImportantValue { get; set; }
    }
}
