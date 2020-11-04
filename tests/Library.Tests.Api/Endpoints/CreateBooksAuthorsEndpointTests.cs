using FluentAssertions;
using Library.Application.UseCases.GetBooksAuthors;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Api.Endpoints
{
    public class CreateBooksAuthorsEndpointTests
    {
        private readonly ITestHost _testHost;

        public CreateBooksAuthorsEndpointTests(ITestHost testHost) => _testHost = testHost;

        [Fact]
        public async Task Shouldnot_CreateBooksAuthorsController_Returns404()
        {
            var route = $"author-books";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<BookAuthorDto>>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            content.Should().BeNull();            
        }
    }
}
