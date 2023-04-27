using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class ProjectRepository : IProjectRepository
    {
        public int Add(Project entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            using (var ctx = new TodoDBContext())
            {
                ctx.Projects.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new TodoDBContext())
            {
                Project currentProject = ctx.Projects.SingleOrDefault(x => x.Id == id);
                if (currentProject == null) return false;
                ctx.Projects.Remove(currentProject);
                ctx.SaveChanges();
                return true;
            }
        }

        public Project Get(int id)
        {
            if (id <= 0) return null;
            using (var ctx = new TodoDBContext())
            {
                Project currentProject = ctx.Projects.SingleOrDefault(x => x.Id == id);
                return currentProject;
            }
        }

        public List<User> GetUsers(int idProject)
        {
            if (idProject <= 0) return null;
            using (var ctx = new TodoDBContext())
            {
                var projectUsers = ctx.UserProjects.Where(up => up.Project.Id == idProject)
                                    .Include(up => up.User).Select(up => up.User).ToList();

                return projectUsers;
            }
        }

  
        public bool RelateTask(Domain.Model.Task newTask)
        {
            throw new NotImplementedException();
        }

        public bool Update(Project entity)
        {
            if (entity == null) return false;
            using (var ctx = new TodoDBContext())
            {
                Project currentProject = ctx.Projects.SingleOrDefault(x => x.Id == entity.Id);
                if (currentProject == null) return false;
                currentProject.ModifiedDate = DateTime.Now;
                currentProject.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
