using System.Collections.Generic;
using Domain.Model;
namespace Data.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        ICollection<Project> GetProjects(int idUser);
        User Login(string username, string password);
        bool RelateProject(int idUser, int idProject);

    }
}