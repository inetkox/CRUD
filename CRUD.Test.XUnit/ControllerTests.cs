using CRUD.WebAPI;
using CRUD.WebAPI.Privilages;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CRUD.Test.XUnit
{
    public class ControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("https://localhost:7000")
            });
        }

        [Fact]
        public async Task GetAllRoles()
        {
            // Arrange
            var response = await _client.GetAsync("/api/Permission");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.NotNull(content);
        }

        [Fact]
        public async Task CreateRole()
        {
            var newRole = new Role
            {
                RoleName = "User"
            };

            var newPostJson = JsonConvert.SerializeObject(newRole);
            var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");


            var response = await _client.PostAsync("/api/Role", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("User", content);
        }

        [Fact]
        public async Task DeleteRole()
        {
            var response = await _client.DeleteAsync("/api/Role/8");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}