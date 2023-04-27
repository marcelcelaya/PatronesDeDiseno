using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        public int Add(Domain.Model.Role entity)
        {
            if (entity == null) return 0;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = null;
            using (var ctx = new TodoDBContext())
            {
                ctx.Roles.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }

        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            using (var ctx = new TodoDBContext())
            {
                Domain.Model.Role currentRole = ctx.Roles.SingleOrDefault(x => x.Id == id);
                if (currentRole == null) return false;
                ctx.Roles.Remove(currentRole);
                ctx.SaveChanges();
                return true;
            }
        }

        public Domain.Model.Role Get(int id)
        {
            if (id <= 0) return null;
            using (var ctx = new TodoDBContext())
            {
                Domain.Model.Role currentRole = ctx.Roles.SingleOrDefault(x => x.Id == id);
                return currentRole;
            }
        }


        public bool RelateRole(Domain.Model.Role newRole)
        {
            throw new NotImplementedException();
        }

        public bool Update(Role entity)
        {
            if (entity == null) return false;
            using (var ctx = new TodoDBContext())
            {
                Role currentRole = ctx.Roles.SingleOrDefault(x => x.Id == entity.Id);
                if (currentRole == null) return false;
                currentRole.ModifiedDate = DateTime.Now;
                currentRole.Name = entity.Name;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}