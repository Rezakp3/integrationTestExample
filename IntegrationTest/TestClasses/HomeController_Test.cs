using IntegrationTest.configuration;
using integrationTestExample.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.TestClasses
{
    public class HomeController_Test : IClassFixture<ApiWebApplicationFactory<Program>>
    {
        private readonly HttpClient Client;
        public HomeController_Test(ApiWebApplicationFactory<Program> api)
        {
            Client = api.CreateClient();
        }

        [Fact]
        public async Task GetAll_Return200()
        {
            var response = await Client.GetAsync("http://localhost/Home/GetAll");
            var res = await response.Content.ReadAsAsync<StandardResult<List<Product>>>();

            res.Success.ShouldBeTrue();
            res.StatusCode.ShouldBe(302);
            res.Result
                .ShouldNotBeNull()
                .ShouldBeOfType<List<Product>>();
        }

        [Fact]
        public async Task GetById_Return200()
        {
            var response = await Client.GetAsync("/Home/GetById/2");
            var res = await response.Content.ReadAsAsync<StandardResult<Product>>();

            res.Success.ShouldBeTrue();
            res.StatusCode.ShouldBe(302);
            res.Result
                .ShouldNotBeNull()
                .ShouldBeOfType<Product>();
        }
    }
}
