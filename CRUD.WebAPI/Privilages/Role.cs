using Microsoft.AspNetCore.Identity;

namespace CRUD.WebAPI.Privilages
{
    public class Role
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public List<Permission>? Permissions { get; set; }
    }
}
