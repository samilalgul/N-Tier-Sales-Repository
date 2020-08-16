using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Sales.API;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Sales.XUnitTest
{
    public class SalesApiTest
    {
        protected readonly HttpClient TestClient;
        private readonly IServiceProvider _serviceProvider;

        protected SalesApiTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                 .WithWebHostBuilder(builder =>
                 {
                     builder.ConfigureServices(services =>
                     {
                         services.RemoveAll(typeof(DataContext));
                         services.AddDbContext<DataContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                     });
                 });

            _serviceProvider = appFactory.Services;
            TestClient = appFactory.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task CustomerGetAllTestAsync(string method)
        {
            //Arrange
            var req = new HttpRequestMessage(new HttpMethod(method), "/api/customer");
            // code goes here
            //Act
            var response = await _client.SendAsync(req);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Theory]
        [InlineData("GET", 1)]
        public async Task CustomerGetByIdTestAsync(string method, int ? id = null)
        {
            //Arrange
            var req = new HttpRequestMessage(new HttpMethod(method), $"/api/customer/{id}");

            var response = await _client.SendAsync(req);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
