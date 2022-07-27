using CRUD.WebAPI.Data;
using CRUD.WebAPI.Privilages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public RoleController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            if (context.Roles == null)
            {
                return NotFound();
            }
            return await context.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Role>>> Get(int id)
        {
            var role = await context.Roles
                .Where(x => x.Id == id)
                .ToListAsync();

            return role;
        }

        [HttpPost]
        public async Task<ActionResult<List<Role>>> Create(RoleDefault roleDefault)
        {
            var newRole = new Role
            {
                RoleName = roleDefault.RoleName
            };

            context.Roles.Add(newRole);
            await context.SaveChangesAsync();

            return await Get(newRole.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            context.Entry(role).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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
        public async Task<ActionResult<List<Role>>> Delete(int id)
        {
            if (context.Roles == null)
            {
                return NotFound();
            }

            var role = await context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return (context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
