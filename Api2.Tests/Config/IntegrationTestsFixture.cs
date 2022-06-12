using Api2.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace Api2.Tests.Config
{
    public class IntegrationTestsFixture
    {

        [CollectionDefinition(nameof(IntegrationTestsFixture))]
        public class IntegrationTestsCollection : ICollectionFixture<IntegrationTestsFixture>
        {
        }

        public HttpClient GetSampleApplicationClient()
        {
            var client = new WebApplicationFactory<Program>().CreateClient();
            client.BaseAddress = new Uri("https://localhost:7001/");

            return client;
        }

        public ICalculaJurosService GetCalculaJurosService()
        {
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create("0.01")
                });

            var httpClient = new HttpClient(mockMessageHandler.Object);
            httpClient.BaseAddress = new Uri("https://localhost:5001/api/");

            var loggerMock = new Mock<ILogger<TaxaJurosHttpClient>>();
            var taxaJurosHttpClient = new TaxaJurosHttpClient(httpClient, loggerMock.Object);
            var service = new CalculaJurosService(taxaJurosHttpClient);

            return service;
        }
    }
}
