using FluentAssertions;
using Library.Application.UseCases.CreateAuthor;
using Library.Application.UseCases.CreateBook;
using Library.Application.UseCases.CreateSubject;
using Library.Application.UseCases.Shared.Dtos;
using Library.Domain.Shared.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

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
            await Should_CreateAuthor_Returns204();

            await Should_CreateSubject_Returns204();

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

        private async Task Should_CreateAuthor_Returns204()
        {
            CreateAuthorRequest createAuthorRequest = new CreateAuthorRequest()
            {
                Name = "Clarrise Lispector",
            };

            var route = $"authors";

            // Acts
            var client = await _testHost.GetClientAsync();
            var stringContent = createAuthorRequest.ToJsonContent();
            var response = await client.PostAsync(route, stringContent);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            await Should_GetAuthors_Returns200();
        }

        private async Task Should_GetAuthors_Returns200()
        {
            var route = $"authors";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<AuthorDto>>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();
            content.Should().OnlyHaveUniqueItems();

            await Should_GetAuthor_Returns200(content.FirstOrDefault().Id);
        }

        private async Task Should_GetAuthor_Returns200(Guid id)
        {
            var route = $"authors/{id}";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<AuthorDto>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();
        }

        private async Task Should_CreateSubject_Returns204()
        {
            CreateSubjectRequest createAuthorRequest = new CreateSubjectRequest()
            {
                Description = "Romance",
            };

            var route = $"subjects";

            // Acts
            var client = await _testHost.GetClientAsync();
            var stringContent = createAuthorRequest.ToJsonContent();
            var response = await client.PostAsync(route, stringContent);

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            await Should_GetSubjects_Returns200();
        }

        private async Task Should_GetSubjects_Returns200()
        {
            var route = $"subjects";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<IEnumerable<SubjectDto>>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();
            content.Should().OnlyHaveUniqueItems();

            await Should_GetSubject_Returns200(content.FirstOrDefault().Id);
        }

        private async Task Should_GetSubject_Returns200(Guid id)
        {
            var route = $"subjects/{id}";

            // Acts
            var client = await _testHost.GetClientAsync();
            var response = await client.GetAsync(route);

            var json = await response.Content.ReadAsStringAsync();
            var content = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<SubjectDto>(json) : null;

            // Asserts
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().NotBeNull();
        }
    }
}
