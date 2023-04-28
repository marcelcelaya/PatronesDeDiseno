using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Todolist2.Model;

namespace Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        public int Add(User entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            using (var ctx = new TodoDBContext())
            {
                ctx.Users.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new TodoDBContext())
            {
                User currentUser = ctx.Users.SingleOrDefault(x => x.Id == id);
                if (currentUser == null) return false;
                ctx.Users.Remove(currentUser);
                ctx.SaveChanges();
                return true;
            }
        }

        public User Get(int id)
        {
            if (id <= 0) return null;
            using (var ctx = new TodoDBContext())
            {
                User currentUser = ctx.Users.SingleOrDefault(x => x.Id == id);
                return currentUser;
            }
        }

        public ICollection<Project> GetProjects(int idUser)
        {
            if (idUser <= 0) return null;
            using (var ctx = new TodoDBContext())
            {
                var userProjects = ctx.UserProjects.Where(up => up.User.Id == idUser)
                                    .Include(up => up.Project).Select(up => up.Project).ToList();

                return userProjects;
            }
        }

        public bool RelateProject(int idUser, int idProject)
        {
            if (idUser <= 0) return false;
            if (idProject <= 0) return false;
            using (var ctx = new TodoDBContext())
            {
                //Obtenemos elusuario y el proyecto a relacionar
                var user = ctx.Users.SingleOrDefault(x => x.Id == idUser);
                var project = ctx.Projects.SingleOrDefault(x => x.Id == idProject);
                //validamos si existe
                if (user == null || project == null) return false;

                var existingRelation = ctx.UserProjects.SingleOrDefault(up => up.User.Id == idUser && up.Project.Id == idProject);
                if (existingRelation != null) return true; // checamos si ya existe la relacion y la validamos

                //Creamos el nuevo objeto
                var userProject = new UserProjects { User = user, Project = project };
                ctx.UserProjects.Add(userProject);
                ctx.SaveChanges();
            }
            return true;
        }

        public bool Update(User entity)
        {
            if (entity == null) return false;
            using (var ctx = new TodoDBContext())
            {
                User currentUser = ctx.Users.SingleOrDefault(x => x.Id == entity.Id);
                if (currentUser == null) return false;
                currentUser.ModifiedDate = DateTime.Now;
                currentUser.UserName = entity.UserName;
                currentUser.Password = entity.Password;
                currentUser.Email = entity.Email;
                currentUser.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }

        public User Login(string username, string password)
        {
            if(username == null || password == null) return null;
            using (var ctx = new TodoDBContext())
            {
                User currentUser = ctx.Users.Where(u => u.Email== username && u.Password == password).FirstOrDefault();
                return currentUser;
            }
        }

    }
}
