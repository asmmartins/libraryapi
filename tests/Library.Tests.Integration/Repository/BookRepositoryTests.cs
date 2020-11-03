using FluentAssertions;
using Library.Domain.Authors;
using Library.Domain.Books;
using Library.Domain.Shared;
using Library.Domain.Subjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests.Integration.Repository
{
    public class BookRepositoryTests
    {
        private readonly IRepository<Book> _bookRepository;

        public BookRepositoryTests(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [Theory]
        [InlineData("Livro 1", "Casa do Saber", 1, "1990", 15.99)]
        [InlineData("Livro 52", "Visão de Mundo", 52, "1993", 16.55)]
        [InlineData("Livro 150", "Tech", 150, "2020", 74.90)]
        public async Task Should_SaveAndGetAllBookInDbContext(string title, string publishingCompany, int edition, string publicationYear, decimal price)
        {
            var authors = new List<Author>() { Author.Create("Ana Carolina Martins"), Author.Create("Caio Paes") };
            var subjects = new List<Subject>() { Subject.Create("Filosofia"), Subject.Create("História") };
            var book = Book.Create(title, publishingCompany, edition, publicationYear, price, subjects, authors);

            await _bookRepository.Save(book);

            var books = await _bookRepository.GetAll();

            books.Should().NotBeNull();
            books.Should().OnlyHaveUniqueItems();

            await _bookRepository.Save(book);

            books = await _bookRepository.GetAll();

            var existent = books.FirstOrDefault(x => x.Id == book.Id);
            existent.Should().Be(book);

            var existents = books.Where(x => x.Id == book.Id).ToList();
            existents.Count.Should().Be(1);

            await _bookRepository.Remove(existent);

            books = await _bookRepository.GetAll();

            existent = books.FirstOrDefault(x => x.Id == book.Id);
            existent.Should().BeNull();

            existents = books.Where(x => x.Id == book.Id).ToList();
            existents.Count.Should().Be(0);
        }
    }
}
