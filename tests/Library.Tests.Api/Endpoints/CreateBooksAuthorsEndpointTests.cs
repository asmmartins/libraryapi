using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Api.Endpoints
{
    public class CreateBooksAuthorsEndpointTests
    {
        private readonly ITestHost _testHost;

        public CreateBooksAuthorsEndpointTests(ITestHost testHost) => _testHost = testHost;

        [Fact]
        public async Task Shouldnot_GetBooksAuthorsController_Returns()
        {
            var route = $"author-books";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            // Asserts            
            response.Should().NotBeNull();
        }
    }
}
