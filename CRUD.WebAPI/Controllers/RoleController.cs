using CRUD.WebAPI.Authorize;
using CRUD.WebAPI.Interfaces;
using CRUD.WebAPI.Privilages;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase 
    {
        private IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [CustomAuthorize("Admin")]
        [HttpGet]
        public async Task<IReadOnlyList<Role>> GetAllRoles()
        {
            return await roleRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(Guid id)
        {
            var role = await roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(Role role)
        {
            await roleRepository.CreateAsync(role);
            return CreatedAtAction("Get", new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            await roleRepository.UpdateAsync(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> Delete(Guid id)
        {
            var role = await roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            await roleRepository.DeleteAsync(role);
            return role;
        }
    }
}
