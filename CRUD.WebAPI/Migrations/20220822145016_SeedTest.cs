using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.WebAPI.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("1f50f51f-b189-4944-b9e1-5ddc7a5c455f"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("414a2973-98a4-448b-9be5-bdda840a4366"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("79ac0b48-9f04-44af-a615-2a3f48cb45a4"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("9600a6dd-fec1-4a29-a664-2a9e5286f0c7"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("ec9062a2-5803-4e63-a62b-4a2c5230d9b8"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781"), "adminek" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "PermissionDescription", "PermissionName", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3b168146-dc1e-46b5-894c-2aee1cadb7eb"), "TODO", "Create", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("b717f8fe-3c4a-407b-88c6-b1625098561c"), "TODO", "Delete", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("d200bbdd-bf60-4b30-9c94-8ff5ccb64731"), "TODO", "Get", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("edab12fc-77af-4c59-8b09-64bfb0285aa8"), "TODO", "Update", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("f09950d4-d252-40be-af43-8f586cee8a90"), "TODO", "GetAll", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("3b168146-dc1e-46b5-894c-2aee1cadb7eb"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b717f8fe-3c4a-407b-88c6-b1625098561c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d200bbdd-bf60-4b30-9c94-8ff5ccb64731"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("edab12fc-77af-4c59-8b09-64bfb0285aa8"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f09950d4-d252-40be-af43-8f586cee8a90"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781"));

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "PermissionDescription", "PermissionName", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1f50f51f-b189-4944-b9e1-5ddc7a5c455f"), "TODO", "Update", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("414a2973-98a4-448b-9be5-bdda840a4366"), "TODO", "Get", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("79ac0b48-9f04-44af-a615-2a3f48cb45a4"), "TODO", "Create", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("9600a6dd-fec1-4a29-a664-2a9e5286f0c7"), "TODO", "Delete", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") },
                    { new Guid("ec9062a2-5803-4e63-a62b-4a2c5230d9b8"), "TODO", "GetAll", new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781") }
                });
        }
    }
}
