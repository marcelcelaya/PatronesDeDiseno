using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IUserService<T> where T : class
    {
        //Create
        int Add(User user);
        //Read
        User Get(int id);
        //Update
        bool Update(User user);
        //Delete
        bool Delete(int id);


    }
}
