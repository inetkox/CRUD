using CRUD.WebAPI.Interfaces;
using CRUD.WebAPI.Privilages;
using Moq;

namespace UnitTest
{
    public class RoleCacheTests
    {
        [Fact]
        public async Task Test()
        {
            //Arrange
            var roleLists = new List<Role>()
            {
                new Role
                {
                    Id = GenerateSeededGuid(5),
                    RoleName = "Admin"
                },
                new Role
                {
                    Id = GenerateSeededGuid(6),
                    RoleName = "User"
                }
            };

            var mockRepo = new Mock<IRoleService>();
            mockRepo.Setup(repo => repo.GetAllRoles()).ReturnsAsync(roleLists);
        }

        public static Guid GenerateSeededGuid(int seed)
        {
            var r = new Random(seed);
            var guid = new byte[16];
            r.NextBytes(guid);

            return new Guid(guid);
        }
    }
}
