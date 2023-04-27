using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        public ProjectService(IProjectRepository ProjectRepo)
        {
            _projectRepo = ProjectRepo;
        }
        public int Add(Project Project)
        {
            if (Project.Id <= 0) return 0;
            return _projectRepo.Add(Project);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_projectRepo.Delete(id));
        }

        public Project Get(int id)
        {
            Project u = _projectRepo.Get(id);
            return u;
        }

        public bool Update(Project Project)
        {
            if (Project.Id <= 0) return false;
            return _projectRepo.Update(Project);
        }

        public List<User> GetUsers(int idProject)
        {
            if(idProject <= 0) return null;
            return _projectRepo.GetUsers(idProject);
        }
    }
}
