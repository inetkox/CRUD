using CRUD.WebAPI.Data;
using CRUD.WebAPI.Privilages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebAPI.Interfaces
{
    public class PermissionRepository : IPermissionRepository, IDisposable
    {
        private readonly ApplicationDbContext context;

        public PermissionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreatePermission(Permission permission)
        {
            context.Permissions.Add(permission);
        }

        public void DeletePermission(Guid id)
        {
            Permission? permission = context.Permissions.Find(id);
            context.Permissions.Remove(permission);
        }

        public Permission GetPermissionById(Guid id)
        {
            return context.Permissions.Find(id);
        }

        public IEnumerable<Permission> GetPermissions()
        {
            return context.Permissions.ToList();
        }

        public void UpdatePermission(Guid id, Permission permission)
        {
            context.Entry(permission).State = EntityState.Modified;
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
