using Domain.Model;
using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        bool RelateTask(Domain.Model.Task newTask);
        List<User> GetUsers(int idProject);
    }
}