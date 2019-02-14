using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Her.Commons.Enums;

namespace Her.Domain.Entities
{
    [Table("Task", Schema = "task")]
    public class TaskModel
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? TodoDate { get; set; }
        public virtual TimeSpan? Remind { get; set; }
        public virtual DateTime UTC { get; set; }
        public virtual bool IsDone { get; set; } = false;
        public virtual long TaskCategoryId { get; set; }
        [ForeignKey("TaskCategoryId")]
        public virtual TaskCategoryModel TaskCategory { get; set; }
    }
}
