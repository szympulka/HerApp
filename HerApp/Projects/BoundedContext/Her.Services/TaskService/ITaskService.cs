using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Her.Services.TaskService
{
    public interface ITaskService
    {
        void RemoveTask(int id);
        void ChangeTaskStatus(int id);
    }
}
