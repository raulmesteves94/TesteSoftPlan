using Api1.Tests.Config;
using System.Net;
using Xunit;

namespace Api1.Tests
{
    [Collection(nameof(IntegrationTestsFixture))]
    public class MainTests
    {
        private readonly IntegrationTestsFixture _fixtures;

        public MainTests(IntegrationTestsFixture fixtures)
        {
            _fixtures = fixtures;
        }

        [Fact]
        public async Task Obter_Taxa_Juros_DeveRetornarComSucesso_200()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("httpss://localhost:7268/");

            // Act
            var resultado = await client.GetAsync("api/Main/taxaJuros");

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }
    }
}