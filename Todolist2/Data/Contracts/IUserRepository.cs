﻿using System.Collections.Generic;
using Domain.Model;
namespace Data.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        ICollection<Project> GetProjects(int idUser);
        bool RelateProject(int idUser, int idProject);

    }
}