using CRUD.WebAPI.Interfaces;
using CRUD.WebAPI.Privilages;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private IPermissionRepository permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        [HttpGet]
        public IEnumerable<Permission> GetAllPermissions()
        {
            return permissionRepository.GetPermissions();
        }

        [HttpGet("{id}")]
        public Permission Get(Guid id)
        {
            return permissionRepository.GetPermissionById(id);
        }

        [HttpPost]
        public Permission Create(Permission permission)
        {
            permissionRepository.CreatePermission(permission);
            permissionRepository.Save();
            return permissionRepository.GetPermissionById(permission.Id);
        }

        [HttpPut("{id}")]
        public Permission Update(Guid id, Permission permission)
        {

            permissionRepository.UpdatePermission(id, permission);
            permissionRepository.Save();
            return permissionRepository.GetPermissionById(permission.Id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            permissionRepository.DeletePermission(id);
            permissionRepository.Save();
            return NoContent();
        }
    }
}
