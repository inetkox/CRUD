using CRUD.WebAPI.Controllers;
using CRUD.WebAPI.Interfaces;
using CRUD.WebAPI.Privilages;
using Moq;
using NSubstitute;

namespace UnitTest
{
    public class RoleControllerTests
    {
        private readonly RoleController _roleController;
        private readonly IRoleRepository _roleRepository = Substitute.For<IRoleRepository>();
        public RoleControllerTests()
        {
            _roleController = new RoleController(_roleRepository);
        }

        [Fact]
        public async Task GetRoleById_Should_Return_Not_Null()
        {
            //Arrange
            var role = new Role
            {
                Id = GenerateSeededGuid(5),
                RoleName = "Admin"
            };

            //Act
            _roleController.Create(role).Returns(await Task.FromResult(role));
            var result = _roleRepository.GetRoleById(GenerateSeededGuid(5));
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllRoles_Should_Return_Correct_Roles()
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
            var mockRepo = new Mock<IRoleRepository>();
            mockRepo.Setup(repo => repo.GetRoles()).Returns(await Task.FromResult<IEnumerable<Role>>(roleLists));
            //Act
            var controller = new RoleController(mockRepo.Object);
            var result = controller.GetAllRoles();
            //Assert
            Assert.Equal(roleLists, result);
        }

        [Fact]
        public async Task Get_Should_Return_One_Role()
        {
            //Arrange
            var role = new Role
            {
                Id = GenerateSeededGuid(5),
                RoleName = "Admin"
            };
            var mockRepo = new Mock<IRoleRepository>();
            mockRepo.Setup(repo => repo.GetRoleById(GenerateSeededGuid(5))).Returns(await Task.FromResult(role));
            //Act
            var controller = new RoleController(mockRepo.Object);
            var result = controller.Get(GenerateSeededGuid(5));
            //Assert
            Assert.Equal(role, result);
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