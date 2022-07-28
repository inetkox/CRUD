using CRUD.WebAPI.Privilages;

namespace CRUD.WebAPI.Interfaces
{
    public interface IRoleRepository : IDisposable
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(Guid id);
        void CreateRole(Role role);
        void DeleteRole(Guid id);
        void UpdateRole(Guid id, Role role);
        void Save();
    }
}
