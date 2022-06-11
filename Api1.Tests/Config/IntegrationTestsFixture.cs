using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api1.Tests.Config
{
    public class IntegrationTestsFixture
    {

        [CollectionDefinition(nameof(IntegrationTestsFixture))]
        public class IntegrationTestsCollection : ICollectionFixture<IntegrationTestsFixture>
        {
        }

        public WebApplicationFactory<Program> GetSampleApplication()
        {
            return new WebApplicationFactory<Program>();
        }
    }
}
