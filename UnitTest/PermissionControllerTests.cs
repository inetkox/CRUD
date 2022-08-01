using CRUD.WebAPI.Controllers;
using CRUD.WebAPI.Interfaces;
using CRUD.WebAPI.Privilages;
using Moq;
using NSubstitute;

namespace UnitTest
{
    public class PermissionControllerTests
    {
        private readonly PermissionController _permissionController;
        private readonly IPermissionRepository _permissionRepository = Substitute.For<IPermissionRepository>();
        public PermissionControllerTests()
        {
            _permissionController = new PermissionController(_permissionRepository);
        }

        [Fact]
        public async Task GetAllPermissions_Should_Return_Correct_Permissions()
        {
            //Arrange
            var permissionLists = new List<Permission>()
            {
                new Permission
                {
                    Id = GenerateSeededGuid(5),
                    PermissionName = "Admin",
                    PermissionDescription = "Has access everywhere"
                },
                new Permission
                {
                    Id = GenerateSeededGuid(6),
                    PermissionName = "User",
                    PermissionDescription = "Has not access everywhere"
                }
            };
            var mockRepo = new Mock<IPermissionRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(permissionLists);
            //Act
            var controller = new PermissionController(mockRepo.Object);
            var result = await controller.GetAllPermissions();
            //Assert
            Assert.Equal(permissionLists, result);
        }

        [Fact]
        public async Task Get_Should_Return_One_Permission()
        {
            //Arrange
            var permission = new Permission
            {
                Id = GenerateSeededGuid(5),
                PermissionName = "Admin",
                PermissionDescription = "Has access everywhere"
            };
            var mockRepo = new Mock<IPermissionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(GenerateSeededGuid(5))).ReturnsAsync(permission);
            //Act
            var controller = new PermissionController(mockRepo.Object);
            var result = await controller.Get(GenerateSeededGuid(5));
            //Assert
            Assert.Equal(permission, result.Value);
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