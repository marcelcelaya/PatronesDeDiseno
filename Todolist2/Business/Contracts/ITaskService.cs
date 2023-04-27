using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Model.Task;

namespace Business.Contracts
{
    public interface ITaskService 
    {
        //Create
        int Add(Task proj);
        //Read
        Task Get(int id);
        //Update
        bool Update(Task proj);
        //Delete
        bool Delete(int id);
    }
}
