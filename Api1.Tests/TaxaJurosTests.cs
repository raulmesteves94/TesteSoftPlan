using Api1.Tests.Config;
using System.Net;
using System.Net.Http.Json;
using Xunit;

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
            client.BaseAddress = new Uri("httpss://localhost:5001/");

            // Act
            var resultado = await client.GetAsync("api/taxaJuros");
            var taxaJuros = resultado.Content.ReadFromJsonAsync<decimal>().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
            Assert.True(taxaJuros == 0.01M);
        }
    }
}