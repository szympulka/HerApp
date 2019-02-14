using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Her.Commons.Enums;

namespace Her.Domain.Entities
{
    [Table("Notification", Schema = "notification")]
    public class NotificationModel
    {
        public virtual long Id { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? ExpirationDate { get; set; }
        public virtual bool IsReaded { get; set; }
        public virtual NotificationImportantValueEnum ImportantValue { get; set; }
        public virtual string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}
