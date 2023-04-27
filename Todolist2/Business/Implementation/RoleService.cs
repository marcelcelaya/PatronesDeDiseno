using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _RoleRepo;
        public RoleService(IRoleRepository RoleRepo)
        {
            _RoleRepo = RoleRepo;
        }
        public int Add(Role Role)
        {
            if (Role.Id <= 0) return 0;
            return _RoleRepo.Add(Role);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return (_RoleRepo.Delete(id));
        }

        public Role Get(int id)
        {
            Role u = _RoleRepo.Get(id);
            return u;
        }

        public bool Update(Role Role)
        {
            if (Role.Id <= 0) return false;
            return _RoleRepo.Update(Role);
        }
    }
}
