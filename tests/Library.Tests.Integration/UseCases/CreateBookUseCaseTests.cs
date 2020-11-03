using FluentAssertions;
using FluentValidation;
using Library.Application.UseCases.CreateBook;
using Library.Application.UseCases.GetBook;
using Library.Application.UseCases.GetBooks;
using Library.Application.UseCases.RemoveBook;
using Library.Tests.Integration.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Integration.UseCases
{
    public class CreateBookUseCaseTests
    {
        private readonly ICreateBookUseCase _createBookUseCase;
        private readonly IGetBookUseCase _getBookUseCase;
        private readonly IGetBooksUseCase _getBooksUseCase;
        private readonly IRemoveBookUseCase _removeBookUseCase;

        public CreateBookUseCaseTests(
            ICreateBookUseCase createBookUseCase,
            IGetBookUseCase getBookUseCase,
            IGetBooksUseCase getBooksUseCase,
            IRemoveBookUseCase removeBookUseCase)
        {
            _createBookUseCase = createBookUseCase;
            _getBookUseCase = getBookUseCase;
            _getBooksUseCase = getBooksUseCase;
            _removeBookUseCase = removeBookUseCase;
        }

        [Theory]
        [InlineData("Livro 9", "Letras vivas", 9, "1975", 19.90)]
        [InlineData("Livro 753", "Puc Editora", 753, "1996", 16.55)]
        [InlineData("Livro 25", "Vida", 25, "2019", 152.25)]
        public async Task Should_CreateBookUseCase(string title, string publishingCompany, int edition, string publicationYear, decimal price)
        {
            CreateBookRequest createBookRequest = new CreateBookRequest()
            {
                Title = title,
                PublishingCompany = publishingCompany,
                Edition = edition,
                PublicationYear = publicationYear,
                Price = price
            };

            await _createBookUseCase.Execute(createBookRequest);

            var books = await _getBooksUseCase.Execute();
            books.Should().NotBeNull();
            books.Should().OnlyHaveUniqueItems();

            var book = books.FirstOrDefault(x => x.Title.ToLower() == createBookRequest.Title.ToLower());

            var existentBook = await _getBookUseCase.Execute(book.Id);
            existentBook.Should().NotBeNull();
            existentBook.Should().BeEquivalentTo(book);

            await _removeBookUseCase.Execute(new RemoveBookRequest() { Id = existentBook.Id });

            existentBook = await _getBookUseCase.Execute(book.Id);
            existentBook.Should().BeNull();
        }

        [Fact]
        public async Task Shouldnot_CreateBookUseCase_WithRequestNull()
        {
            ArgumentNullException ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _createBookUseCase.Execute(null));
            ex.Should().NotBeNull();
            ex.Message.Should().Be("Value cannot be null. (Parameter 'CreateBookRequest')");
        }

        [Fact]
        public async Task Shouldnot_CreateBookUseCase_WithTitleNull()
        {
            var request = new CreateBookRequest() { Title = null };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createBookUseCase.Execute(request));
            ex.AssertErrorMessage("'Title' não pode ser nulo.");
        }
    }
}