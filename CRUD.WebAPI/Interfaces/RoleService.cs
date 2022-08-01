using CRUD.WebAPI.Privilages;

namespace CRUD.WebAPI.Interfaces
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly ICacheRepository cacheRepository;
        private static string getAllRolesKey = "GetAllRolesKey";

        public RoleService(IRoleRepository roleRepository, ICacheRepository cacheRepository)
        {
            this.roleRepository = roleRepository;
            this.cacheRepository = cacheRepository;
        }

        public async Task<IReadOnlyCollection<Role>> GetAllRoles()
        {
            if (cacheRepository.TryGet(getAllRolesKey, out IReadOnlyCollection<Role> result))
            {
                return result;
            }
            else
            {
                result = await roleRepository.GetAllAsync();
                cacheRepository.Set(getAllRolesKey, result);
            }

            return result;
        }
    }
}
