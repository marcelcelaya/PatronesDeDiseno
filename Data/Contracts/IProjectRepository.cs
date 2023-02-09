using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;
namespace Data.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        bool RelateTask(Domain.Model.Task newTask);
    }
}
