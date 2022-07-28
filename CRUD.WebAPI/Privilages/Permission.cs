using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.WebAPI.Privilages
{
    public class Permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string? PermissionName { get; set; }

        [Required]
        [MaxLength(30)]
        public string? PermissionDescription { get; set; }
        public Role? Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
