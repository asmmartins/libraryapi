using FluentAssertions;
using Library.Application.UseCases.CreateGroup;
using Library.Application.UseCases.CreateBook;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Shared.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace Library.Tests.Api.Endpoints
{
    public class CreateBookEndpointTests
    {
        private readonly ITestHost _testHost;

        public CreateBookEndpointTests(ITestHost testHost) => _testHost = testHost;

        [Theory]
        [InlineData("Livro 10", "Liberdade e Paz", 3, "1952", 85.99)]
        [InlineData("Livro 85", "Puc Editora", 85, "2020", 16.96)]
        [InlineData("Livro 25", "Vida", 25, "2019", 152.25)]
        public async Task Should_CreateBookController_Returns204(string title, string publishingCompany, int edition, string publicationYear, decimal price)
        {
            CreateBookRequest createBookRequest = new CreateBookRequest()
            {
                Title = title,
                PublishingCompany = publishingCompany,
                Edition = edition,
                PublicationYear = publicationYear,
                Price = price
            };

            var route = $"books";

            // Acts
            var client = await _testHost.GetClientAsync();
            var stringContent = createBookRequest.ToJsonContent();
            var response = await client.PostAsync(route, stringContent);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            await Should_GetBooks_Returns200();
        }

        private async Task Should_GetBooks_Returns200()
        {
            var route = $"books";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<BookDto>>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();
            content.Should().OnlyHaveUniqueItems();

            await Should_GetBook_Returns200(content.FirstOrDefault().Id);
        }

        private async Task Should_GetBook_Returns200(Guid id)
        {
            var route = $"books/{id}";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<BookDto>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();            
        }

        private async Task Should_CreateGroupInSchool_Returns204(string inep)
        {
            CreateGroupRequest createGroupRequest = new CreateGroupRequest()
            {
                Inep = inep,
                Name = "Escola Novo Amanhã",
            };

            var route = $"public-schools/{inep}/groups";

            // Acts
            var client = await _testHost.GetClientAsync();
            var stringContent = createGroupRequest.ToJsonContent();
            var response = await client.PostAsync(route, stringContent);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }                

        private async Task Should_GetGroupsFromBook_Returns200(string inep)
        {
            var route = $"public-schools/{inep}/groups";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<GroupDto>>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();

            foreach (var c in content)
                await Should_GetGroupFromId_Returns200(c.Id);
        }

        private async Task Should_GetGroupFromId_Returns200(Guid id)
        {
            var route = $"groups/{id}";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<GroupDto>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();
        }
    }
}
