using CRUD.WebAPI.Privilages;

namespace CRUD.WebAPI.Interfaces
{
    public interface IPermissionRepository : IDisposable
    {
        IEnumerable<Permission> GetPermissions();
        Permission GetPermissionById(Guid id);
        void CreatePermission(Permission permission);
        void DeletePermission(Guid id);
        void UpdatePermission(Guid id, Permission permission);
        void Save();
    }
}
