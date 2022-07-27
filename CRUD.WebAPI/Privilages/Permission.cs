using System.Text.Json.Serialization;

namespace CRUD.WebAPI.Privilages
{
    public class Permission
    {
        public int Id { get; set; }
        public string? PermissionName { get; set; }
        public string? PermissionDescription { get; set; }
        [JsonIgnore]
        public Role? Role { get; set; }
        public int RoleId { get; set; }
    }
}
