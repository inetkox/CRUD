using CRUD.WebAPI.Data;
using CRUD.WebAPI.Privilages;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void InsertDataIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(
                "InsertDataIntoDatabase");

            using var context = new ApplicationDbContext(builder.Options);
            var role = new Role { RoleName = "User" };
            context.Roles.Add(role);
            Assert.AreEqual(EntityState.Added, context.Entry(role).State);
        }
    }
}