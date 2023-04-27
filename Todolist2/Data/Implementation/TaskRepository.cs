using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class TaskRepository : ITaskRepository
    {
        public int Add(Domain.Model.Task entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            using (var ctx = new TodoDBContext())
            {
                ctx.Tasks.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new TodoDBContext())
            {
                Domain.Model.Task currentTask = ctx.Tasks.SingleOrDefault(x => x.Id == id);
                if (currentTask == null) return false;
                ctx.Tasks.Remove(currentTask);
                ctx.SaveChanges();
                return true;
            }
        }

        public Domain.Model.Task Get(int id)
        {
            if (id <= 0) return null;
            using (var ctx = new TodoDBContext())
            {
                Domain.Model.Task currentTask = ctx.Tasks.SingleOrDefault(x => x.Id == id);
                return currentTask;
            }
        }


        public bool RelateTask(Domain.Model.Task newTask)
        {
            throw new NotImplementedException();
        }

        public bool Update(Domain.Model.Task entity)
        {
            if (entity == null) return false;
            using (var ctx = new TodoDBContext())
            {
                Domain.Model.Task currentTask = ctx.Tasks.SingleOrDefault(x => x.Id == entity.Id);
                if (currentTask == null) return false;
                currentTask.ModifiedDate = DateTime.Now;
                currentTask.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}