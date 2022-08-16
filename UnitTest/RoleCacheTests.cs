using CRUD.WebAPI.Controllers;
using CRUD.WebAPI.Interfaces;
using CRUD.WebAPI.Privilages;
using Moq;

namespace UnitTest
{
    public class RoleCacheTests
    {
        [Fact]
        public async Task GetAllRoles_Should_Return_Correct_Cache_Roles()
        {
            //Arrange
            var roleList = new List<Role>()
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

            var mockRoleRepository = new Mock<IRoleRepository>();
            var mockCacheRepository = new Mock<ICacheRepository>();
            mockCacheRepository.Setup(repo => repo.TryGet(It.IsAny<string>(), out roleList)).Returns(true);
            //Act
            var service = new RoleService(mockRoleRepository.Object, mockCacheRepository.Object);
            var result = await service.GetAllRoles();
            //Assert
            Assert.Equal(roleList, result);
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
