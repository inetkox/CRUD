using CRUD.WebAPI.Data;
using CRUD.WebAPI.Privilages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebAPI.Interfaces
{
    public class RoleRepository : IRoleRepository, IDisposable
    {
        private readonly ApplicationDbContext context;

        public RoleRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateRole(Role role)
        {
            context.Roles.Add(role);
        }

        public void DeleteRole(Guid id)
        {
            Role? role = context.Roles.Find(id);
            context.Roles.Remove(role);
        }

        public Role GetRoleById(Guid id)
        {
            return context.Roles.Find(id);
        }

        public IEnumerable<Role> GetRoles()
        {
            return context.Roles.ToList();
        }

        public void UpdateRole(Guid id, Role role)
        {
            context.Entry(role).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
