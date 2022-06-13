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

        [Theory]
        [InlineData(100, 2, 102.01)]
        [InlineData(200, 6, 212.30)]
        [InlineData(400, 7, 428.85)]
        [InlineData(700, 8, 757.99)]
        public async Task Calcula_Juros_Composto_DeveRetornarValoresCorretos(decimal valorInicial, int mes, decimal valorTotal)
        {
            // Arrange
            var service = _fixtures.GetCalculaJurosService();

            // Act
            var resultado = await service.Calcular(valorInicial, mes);

            // Assert
            Assert.Equal(valorTotal, resultado, 2);
        }
    }
}