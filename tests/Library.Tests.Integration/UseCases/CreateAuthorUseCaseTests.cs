using FluentAssertions;
using FluentValidation;
using Library.Application.UseCases.CreateAuthor;
using Library.Application.UseCases.GetAuthor;
using Library.Application.UseCases.GetAuthors;
using Library.Application.UseCases.RemoveAuthor;
using Library.Tests.Integration.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Integration.UseCases
{
    public class CreateAuthorUseCaseTests
    {
        private readonly ICreateAuthorUseCase _createAuthorUseCase;
        private readonly IGetAuthorUseCase _getAuthorUseCase;
        private readonly IGetAuthorsUseCase _getAuthorsUseCase;
        private readonly IRemoveAuthorUseCase _removeAuthorUseCase;

        public CreateAuthorUseCaseTests(
            ICreateAuthorUseCase createAuthorUseCase,
            IGetAuthorUseCase getAuthorUseCase,
            IGetAuthorsUseCase getAuthorsUseCase,
            IRemoveAuthorUseCase removeAuthorUseCase)
        {
            _createAuthorUseCase = createAuthorUseCase;
            _getAuthorUseCase = getAuthorUseCase;
            _getAuthorsUseCase = getAuthorsUseCase;
            _removeAuthorUseCase = removeAuthorUseCase;
        }

        [Theory]
        [InlineData("Renato Ferreira Pontes")]
        [InlineData("Alex Silva Martins")]
        [InlineData("Paulo Coelho")]
        public async Task Should_CreateAuthorUseCase(string name)
        {
            CreateAuthorRequest createAuthorRequest = new CreateAuthorRequest()
            {
                Name = name
            };

            await _createAuthorUseCase.Execute(createAuthorRequest);

            var authors = await _getAuthorsUseCase.Execute();
            authors.Should().NotBeNull();
            authors.Should().OnlyHaveUniqueItems();

            var author = authors.FirstOrDefault(x => x.Name.ToLower() == createAuthorRequest.Name.ToLower());

            var existentAuthor = await _getAuthorUseCase.Execute(author.Id);
            existentAuthor.Should().NotBeNull();
            existentAuthor.Should().BeEquivalentTo(author);

            await _removeAuthorUseCase.Execute(new RemoveAuthorRequest() { Id = existentAuthor.Id });

            existentAuthor = await _getAuthorUseCase.Execute(author.Id);
            existentAuthor.Should().BeNull();
        }

        [Fact]
        public async Task Shouldnot_CreateAuthorUseCase_WithRequestNull()
        {
            ArgumentNullException ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _createAuthorUseCase.Execute(null));
            ex.Should().NotBeNull();
            ex.Message.Should().Be("Value cannot be null. (Parameter 'CreateAuthorRequest')");
        }

        [Fact]
        public async Task Shouldnot_CreateAuthorUseCase_WithNameNull()
        {
            var request = new CreateAuthorRequest() { Name = null };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createAuthorUseCase.Execute(request));
            ex.AssertErrorMessage("'Name' não pode ser nulo.");
        }
    }
}