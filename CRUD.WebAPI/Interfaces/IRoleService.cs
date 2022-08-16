using CRUD.WebAPI.Privilages;

namespace CRUD.WebAPI.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
    }
}