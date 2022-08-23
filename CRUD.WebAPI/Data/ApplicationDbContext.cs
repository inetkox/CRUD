using CRUD.WebAPI.Enums;
using CRUD.WebAPI.Privilages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static CRUD.WebAPI.Enums.PermissionEnum;

namespace CRUD.WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Permission>().HasData(EnumConversion.GetElementsFromEnum<Permission, PermissionsEnums>());

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781"),
                RoleName = "adminek",
            });
        }
    }
}