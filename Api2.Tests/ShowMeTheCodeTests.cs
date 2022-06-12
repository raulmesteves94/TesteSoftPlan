using Api2.Tests.Config;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Api2.Tests
{
    [Collection(nameof(IntegrationTestsFixture))]
    public class ShowMeTheCodeTests
    {
        private readonly IntegrationTestsFixture _fixtures;

        public ShowMeTheCodeTests(IntegrationTestsFixture fixtures)
        {
            _fixtures = fixtures;
        }

        [Fact]
        public async Task Show_Me_The_Code_DeveRetornarComSucesso_200()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("https://localhost:7001/");

            // Act
            var resultado = await client.GetAsync("api/showMeTheCode");
            var link = resultado.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
            Assert.NotNull(link);
        }
    }
}