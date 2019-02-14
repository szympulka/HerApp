using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Her.Domain.Entities;

namespace Her.Domain.Entities
{
    [Table("TaskCategory", Schema = "task")]
    public class TaskCategoryModel
    {
        public virtual long Id { get; set; }
        [MaxLength(20)]
        public virtual string Name { get; set; }
        public virtual string UserGuid { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; }
        [ForeignKey("UserGuid")]
        public virtual ApplicationUser User { get; set; }
    }
}
