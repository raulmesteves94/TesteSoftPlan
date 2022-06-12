using Api2.Tests.Config;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Api2.Tests
{
    [Collection(nameof(IntegrationTestsFixture))]
    public class CalculaJurosTests
    {
        private readonly IntegrationTestsFixture _fixtures;

        public CalculaJurosTests(IntegrationTestsFixture fixtures)
        {
            _fixtures = fixtures;
        }

        [Fact]
        public async Task Calcula_Juros_Composto_DeveRetornarComSucesso_200()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");

            // Act
            var resultado = await client.GetAsync($"api/calculajuros?valorInicial=100&tempo=5");

            // Assert
            Assert.Equal(HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact]
        public async Task Calcula_Juros_Composto_DeveRetornarComErroValorInicial_400()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");

            // Act
            var resultado = await client.GetAsync($"api/calculajuros?valorInicial=0&tempo=5");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, resultado.StatusCode);
        }

        [Fact]
        public async Task Calcula_Juros_Composto_DeveRetornarComErroTempo_400()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");

            // Act
            var resultado = await client.GetAsync($"api/calculajuros?valorInicial=100&tempo=0");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, resultado.StatusCode);
        }

        [Fact]
        public void Calcula_Juros_Composto_RetornarValorCalculo()
        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");

            // Act
            var response = client.GetAsync($"api/calculajuros?valorInicial=100&tempo=5").Result;
            var resultado = response.Content.ReadFromJsonAsync<decimal>().Result;

            // Assert
            Assert.Equal(105.10M, resultado);
        }

        [Theory]
        [InlineData(100, 2, 102.01)]
        [InlineData(200, 6, 212.30)]
        [InlineData(400, 7, 428.85)]
        [InlineData(700, 8, 758.00)]
        public void Calcula_Juros_Composto_DeveRetornarValoresCorretos(decimal valorInicial, int mes, decimal valorTotal)

        {
            // Arrange
            var client = _fixtures.GetSampleApplication().CreateClient();
            client.BaseAddress = new Uri("https://localhost:7188/");            

            // Act
            var response = client.GetAsync($"api/calculajuros?valorInicial={valorInicial}&tempo={mes}").Result;
            var resultado = response.Content.ReadFromJsonAsync<decimal>().Result;
            // Assert
            Assert.Equal(valorTotal, resultado);
        }
    }
}