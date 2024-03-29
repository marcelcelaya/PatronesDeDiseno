﻿using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public int Add(User user)
        {
            if (user.Id <= 0) return 0;
            if (string.IsNullOrEmpty(user.Email)) return 0;
            if (string.IsNullOrEmpty(user.Password)) return 0;
            return _userRepo.Add(user);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_userRepo.Delete(id));
        }

        public User Get(int id)
        {
            User u = _userRepo.Get(id);
            return u;
        }

        public bool Update(User user)
        {
            if (user.Id <= 0) return false;
            if (string.IsNullOrEmpty(user.Email)) return false;
            if (string.IsNullOrEmpty(user.Password)) return false;
            return _userRepo.Update(user);
        }

        public bool RelateProject(int idUser, int idProject)
        {
            if (idUser <= 0) return false;
            if (idProject <= 0) return false;
            return _userRepo.RelateProject(idUser, idProject);
        }
        public ICollection<Project> GetProjects(int idUser)
        {
            if (idUser <= 0) return null;
            List<Project> projectList = _userRepo.GetProjects(idUser).ToList();
            return projectList;
        }

        public User Login(string username, string password)
        {
            if(username== null || password == null) return null;
            return _userRepo.Login(username, password);
        }
    }
}
