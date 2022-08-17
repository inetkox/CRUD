using CRUD.WebAPI.Data;
using CRUD.WebAPI.Privilages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebAPI.Interfaces
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly DbSet<Role> roles;

        public RoleRepository(ApplicationDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
        {
            roles = context.Set<Role>();
            roles.Include(x => x.Permissions).ToList();
        }
    }
}
