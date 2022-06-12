using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Api2.Tests.Config
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
