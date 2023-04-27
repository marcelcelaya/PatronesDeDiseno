using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Model.Task;

namespace Business.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _TaskRepo;
        public TaskService(ITaskRepository TaskRepo)
        {
            _TaskRepo = TaskRepo;
        }
        public int Add(Task Task)
        {
            if (Task.Id <= 0) return 0;
            return _TaskRepo.Add(Task);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_TaskRepo.Delete(id));
        }

        public Task Get(int id)
        {
            Task u = _TaskRepo.Get(id);
            return u;
        }

        public bool Update(Task Task)
        {
            if (Task.Id <= 0) return false;
            return _TaskRepo.Update(Task);
        }
    }
}
