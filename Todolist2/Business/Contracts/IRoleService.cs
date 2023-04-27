using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IRoleService
    {
        //Create
        int Add(Role proj);
        //Read
        Role Get(int id);
        //Update
        bool Update(Role proj);
        //Delete
        bool Delete(int id);

    }
}
