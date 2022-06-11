using Api1.Tests.Config;
using System.Net;
using System.Net.Http.Json;

namespace Api1.Tests
{
    [Collection(nameof(IntegrationTestsFixture))]
    public class TaxaJurosTests
    {
        private readonly IntegrationTestsFixture _fixtures;

        public TaxaJurosTests(IntegrationTestsFixture fixtures)
        {
            _fixtures = fixtures;
        }

        [Fact]
        public async Task Obter_Taxa_Juros_DeveRetornarComSucesso_200()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("http://localhost:49159/");

            // Act
            var resultado = await client.GetAsync("api/Main/taxaJuros");

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact]
        public async Task Obter_Taxa_Juros_DeveRetornarComErro_404()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("http://localhost:49159/");

            // Act
            var resultado = await client.GetAsync("api/Juros/taxaJuros");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, resultado.StatusCode);
        }
    }
}