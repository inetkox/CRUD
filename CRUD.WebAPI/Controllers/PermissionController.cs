using CRUD.WebAPI.Authorize;
using CRUD.WebAPI.Enums;
using CRUD.WebAPI.Interfaces;
using CRUD.WebAPI.Privilages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CRUD.WebAPI.Enums.PermissionEnum;

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

        [CustomAuthorize(PermissionsEnums.GetAll)]
        [HttpGet]
        public async Task<IReadOnlyList<Permission>> GetAllPermissions()
        {
            return await permissionRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> Get(Guid id)
        {
            var permission = await permissionRepository.GetByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        [HttpPost]
        public async Task<ActionResult<Permission>> Create(Permission permission)
        {
            await permissionRepository.CreateAsync(permission);
            return CreatedAtAction("Get", new { id = permission.Id }, permission);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Permission permission)
        {
            if (id != permission.Id)
            {
                return BadRequest();
            }

            await permissionRepository.UpdateAsync(permission);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Permission>> Delete(Guid id)
        {
            var permission = await permissionRepository.GetByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            await permissionRepository.DeleteAsync(permission);
            return permission;
        }
    }
}
