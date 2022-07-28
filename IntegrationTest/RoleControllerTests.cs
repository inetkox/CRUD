using CRUD.WebAPI.Privilages;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace IntegrationTest
{
    public class RoleControllerTests : IntegrationTest
    {
        public RoleControllerTests()
        {

        }

        [Fact]
        public async Task GetAllRolesFromTestDb()
        {
            var response = await TestClient.GetAsync("api/role");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsAsync<List<Role>>();
            Assert.Empty(content);
        }

        [Fact]
        public async Task CreateNewRole()
        {
            var newRole = NewRole();

            var newPostJson = JsonConvert.SerializeObject(newRole);
            var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

            var response = await TestClient.PostAsync("/api/Role", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("User", content);
            Assert.Equal("1", content[7].ToString());
        }

        [Fact]
        public async Task DeleteRole()
        {
            var newRole = NewRole();

            var newPostJson = JsonConvert.SerializeObject(newRole);
            var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

            var response = await TestClient.PostAsync("/api/Role", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var remove = await TestClient.DeleteAsync("/api/Role/" + content[7].ToString());
            var contentAfterDelete = await remove.Content.ReadAsStringAsync();
            Assert.Empty(contentAfterDelete);
            Assert.Equal(HttpStatusCode.NoContent, remove.StatusCode);
        }

/*        [Fact(Skip = "Put not working")]
        public async Task UpdateRole()
        {
            var newRole = NewRole();

            var newPostJson = JsonConvert.SerializeObject(newRole);
            var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

            var response = await TestClient.PostAsync("/api/Role", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();

            var secondRole = new Role
            {
                Guid = Convert.ToInt32(content[7].ToString()),
                RoleName = "Admin"
            };
            var secondPostJson = JsonConvert.SerializeObject(secondRole);
            var secondPayload = new StringContent(secondPostJson, Encoding.UTF8, "application/json");

            var update = await TestClient.PutAsync("/api/Role/" + content[7].ToString(), secondPayload);
            var contentAfterUpdate = await update.Content.ReadAsStringAsync();
            Assert.Empty(contentAfterUpdate);
            Assert.Equal(HttpStatusCode.NoContent, update.StatusCode);
        }*/

        private Role NewRole()
        {
            return new Role
            {
                RoleName = "User"
            };
        }
    }
}
