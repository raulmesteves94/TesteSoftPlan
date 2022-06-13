using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api1.Tests.Config
{
    public class IntegrationTestsFixture
    {

        [CollectionDefinition(nameof(IntegrationTestsFixture))]
        public class IntegrationTestsCollection : ICollectionFixture<IntegrationTestsFixture>
        {
        }

        public HttpClient GetSampleApplication()
        {
            var client = new WebApplicationFactory<Program>().CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001/");

            return client;
        }
    }
}
