using System;
using System.Collections.Generic;
using System.Text;
using Her.Domain.Entities;

namespace Her.Repository.Task
{
    public class TaskCategoryRepository: SqlRepository<TaskCategoryModel>, ITaskCategoryRepository
    {
    }
}
