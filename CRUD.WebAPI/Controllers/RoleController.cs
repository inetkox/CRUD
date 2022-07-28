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

        [HttpGet]
        public IEnumerable<Role> GetAllRoles()
        {
            return roleRepository.GetRoles();
        }

        [HttpGet("{id}")]
        public Role Get(Guid id)
        {
            return roleRepository.GetRoleById(id);
        }

        [HttpPost]  
        public Role Create(Role role)
        {
            roleRepository.CreateRole(role);
            roleRepository.Save();
            return roleRepository.GetRoleById(role.Id);
        }

        [HttpPut("{id}")]
        public Role Update(Guid id, Role role)
        {
            roleRepository.UpdateRole(id, role);
            roleRepository.Save();
            return roleRepository.GetRoleById(role.Id);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            roleRepository.DeleteRole(id);
            roleRepository.Save();
            return NoContent();
        }
    }
}
