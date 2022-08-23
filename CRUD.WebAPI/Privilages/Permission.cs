using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static CRUD.WebAPI.Enums.PermissionEnum;

namespace CRUD.WebAPI.Privilages
{
    public class Permission : IPermission<Permission, PermissionsEnums>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? PermissionName { get; set; }

        [Required]
        [MaxLength(30)]
        public string? PermissionDescription { get; set; }

        public Role? Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
