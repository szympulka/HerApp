using System;
using System.Collections.Generic;
using System.Text;
using Her.Domain.Entities;

namespace Her.Repository.Task
{
    public interface ITaskRepository: ISqlRepository<TaskModel>
    {
    }
}
