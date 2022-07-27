using CRUD.WebAPI.Privilages;
using System.Net;

namespace IntegrationTest
{
    public class PermissionControllerTests : IntegrationTest
    {
        public PermissionControllerTests()
        {

        }   

        [Fact]
        public async Task GetAllPermission()
        {
            var response = await TestClient.GetAsync("/api/Permission");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsAsync<List<Permission>>();
            Assert.Empty(content);
        }
    }
}
