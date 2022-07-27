using CRUD.WebAPI.Data;
using CRUD.WebAPI.Privilages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PermissionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Permission>>> Get(int roleId)
        {
            var permission = await context.Permissions
                .Where(x => x.RoleId == roleId)
                .ToListAsync();

            return permission;
        }

        [HttpPost]
        public async Task<ActionResult<List<Permission>>> Create(PermissionDefault permissionDefault)
        {
            var role = await context.Roles.FindAsync(permissionDefault.RoleId);
            if (User == null)
                return NotFound();

            var newPermission = new Permission
            {
                PermissionName = permissionDefault.PermissionName,
                PermissionDescription = permissionDefault.PermissionDescription,
                Role = role,
            };

            context.Permissions.Add(newPermission);
            await context.SaveChangesAsync();

            return await Get(newPermission.RoleId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Permission permission)
        {
            if (id != permission.Id)
            {
                return BadRequest();
            }

            context.Entry(permission).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Permission>>> Delete(int id)
        {
            if (context.Permissions == null)
            {
                return NotFound();
            }
            var permission = await context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            context.Permissions.Remove(permission);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionExists(int id)
        {
            return (context.Permissions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
