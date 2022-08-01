using CRUD.WebAPI.Data;
using CRUD.WebAPI.Privilages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebAPI.Interfaces
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly DbSet<Permission> permissions;

        public PermissionRepository(ApplicationDbContext context, ICacheRepository cacheRepository) : base(context, cacheRepository)
        {
            permissions = context.Set<Permission>();
        }
    }
}

